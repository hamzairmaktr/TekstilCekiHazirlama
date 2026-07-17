using QuestPDF;
using QuestPDF.Infrastructure;

namespace TekstilCekiHazirlama;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Declare QuestPDF license tier before generating documents.
        Settings.License = LicenseType.Evaluation;

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}