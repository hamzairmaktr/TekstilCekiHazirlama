using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TekstilCekiHazirlama
{
    public static class AppSettingsService
    {
        private static string SettingsFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

        public static AppSettings Load()
        {
            try
            {
                if (!File.Exists(SettingsFilePath))
                {
                    var defaultSettings = new AppSettings();
                    Save(defaultSettings);
                    return defaultSettings;
                }

                var json = File.ReadAllText(SettingsFilePath);
                var settings = JsonSerializer.Deserialize<AppSettings>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return settings ?? new AppSettings();
            }
            catch
            {
                return new AppSettings();
            }
        }

        public static void Save(AppSettings settings)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(SettingsFilePath, json);
        }
    }

    public static class DataService
    {
        public static void EnsureDatabase()
        {
            using var db = new AppDbContext();
            db.Database.EnsureCreated();
        }

        public static string CreateNextDocumentNo()
        {
            using var db = new AppDbContext();
            var year = DateTime.Now.Year;
            var prefix = year.ToString();
            var lastDocument = db.DeliveryNotes
                .AsNoTracking()
                .Where(x => x.DocumentNo.StartsWith(prefix))
                .OrderByDescending(x => x.DocumentNo)
                .Select(x => x.DocumentNo)
                .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(lastDocument) || lastDocument.Length < prefix.Length + 6)
            {
                return prefix + "000001";
            }

            var numberPart = lastDocument.Substring(prefix.Length);
            if (!int.TryParse(numberPart, out var lastNumber))
                lastNumber = 0;

            return prefix + (lastNumber + 1).ToString("D6");
        }

        public static List<DeliveryNote> GetDeliveryNotes(string search = "")
        {
            using var db = new AppDbContext();
            var notes = db.DeliveryNotes.Include(d => d.Items).AsNoTracking().ToList();

            if (string.IsNullOrWhiteSpace(search))
            {
                return notes.OrderByDescending(x => x.Date).ThenByDescending(x => x.Id).ToList();
            }

            search = search.Trim().ToLowerInvariant();
            return notes
                .Where(x => x.DocumentNo.Contains(search, StringComparison.OrdinalIgnoreCase)
                            || x.CustomerName.Contains(search, StringComparison.OrdinalIgnoreCase)
                            || x.Date.ToString("yyyy-MM-dd").Contains(search, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(x => x.Date)
                .ThenByDescending(x => x.Id)
                .ToList();
        }

        public static DeliveryNote? GetDeliveryNoteById(int id)
        {
            using var db = new AppDbContext();
            return db.DeliveryNotes.Include(x => x.Items).FirstOrDefault(x => x.Id == id);
        }

        public static void DeleteDeliveryNote(int id)
        {
            using var db = new AppDbContext();
            var note = db.DeliveryNotes.Include(x => x.Items).FirstOrDefault(x => x.Id == id);
            if (note is null)
                return;

            db.DeliveryNotes.Remove(note);
            db.SaveChanges();
        }

        public static List<string> GetCustomerNames()
        {
            using var db = new AppDbContext();
            return db.DeliveryNotes.AsNoTracking()
                .Where(x => !string.IsNullOrWhiteSpace(x.CustomerName))
                .Select(x => x.CustomerName.Trim())
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        public static List<string> GetProductNames()
        {
            using var db = new AppDbContext();
            return db.DeliveryNoteItems.AsNoTracking()
                .Where(x => !string.IsNullOrWhiteSpace(x.ProductName))
                .Select(x => x.ProductName.Trim())
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        public static void SaveDeliveryNote(DeliveryNote note)
        {
            using var db = new AppDbContext();
            if (note.Id == 0)
            {
                db.DeliveryNotes.Add(note);
            }
            else
            {
                var existing = db.DeliveryNotes.Include(x => x.Items).FirstOrDefault(x => x.Id == note.Id);
                if (existing is null)
                {
                    db.DeliveryNotes.Add(note);
                }
                else
                {
                    existing.DocumentNo = note.DocumentNo;
                    existing.Date = note.Date;
                    existing.CustomerName = note.CustomerName;
                    existing.Address = note.Address;
                    existing.Phone = note.Phone;
                    existing.ReceiverName = note.ReceiverName;
                    existing.TotalRoll = note.TotalRoll;
                    existing.TotalKg = note.TotalKg;
                    existing.TotalAmount = note.TotalAmount;

                    db.DeliveryNoteItems.RemoveRange(existing.Items);
                    foreach (var item in note.Items)
                    {
                        item.DeliveryNoteId = existing.Id;
                        db.DeliveryNoteItems.Add(item);
                    }
                }
            }

            db.SaveChanges();
        }
    }
}
