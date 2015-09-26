using System;
using System.Linq;
using PPT = Microsoft.Office.Interop.PowerPoint;
using Word = Microsoft.Office.Interop.Word;

namespace UmlElementLink
{
  static class Office
  {
    /// <summary>
    /// Opens a Word file and moves to the specified bookmark.
    /// Assumes the bookmark is uppercase.
    /// </summary>
    /// <param name="file">Full path</param>
    /// <param name="bookmarkName">name of bookmark</param>
    /// <returns>Opened the file</returns>
    internal static bool TryOpenFileInWord(string file, string bookmarkName)
    {
      Object fileName = file;
      Word::Application word = GetApplication("Word.Application") as Word::Application;
      word.Visible = true;
      // Open it or find an existing open instance:
      Word::Document wordDoc = word.Documents.Open(ref fileName);
      if (wordDoc == null) return false;
      if (!string.IsNullOrEmpty(bookmarkName))
      {
        try
        {
          Object name = bookmarkName.ToUpperInvariant();
          Word::Bookmark bookMark = wordDoc.Bookmarks.get_Item(ref name);
          wordDoc.ActiveWindow.ScrollIntoView(bookMark.Range);
          bookMark.Select();
        }
        catch (System.Runtime.InteropServices.COMException)
        {
          System.Windows.Forms.MessageBox.Show("Bookmark not found.\n"
          + "Did you forget to save the doc after creating the link?");
        }
      }
      word.Activate();
      wordDoc.Activate();
      return true;
    }

    /// <summary>
    /// Open a PPT file and select the specified slide.
    /// </summary>
    /// <param name="file">Full path</param>
    /// <param name="slideNumber">Can be empty</param>
    /// <returns>Opened the file</returns>
    internal static bool TryOpenFileInPpt(string file, string slideNumber)
    {
      PPT::Application ppt = GetApplication("PowerPoint.Application") as PPT.Application;
      ppt.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
      // Find the presentation if it's already open:
      PPT::Presentation presentation = ppt.Presentations.OfType<PPT::Presentation>()
        .FirstOrDefault(p => p.FullName.Equals(file, StringComparison.InvariantCultureIgnoreCase));

      if (presentation == null)
      {
        presentation = ppt.Presentations.Open(file);
      }
      if (presentation == null)
      {
        return false;
      }

      // Select the slide:
      int index = 1;
      int.TryParse(slideNumber, out index);
      if (presentation.Slides.Count >= index)
      {
        presentation.Slides[index].Select();
      }
      ppt.Activate();
      presentation.Windows[1].Activate();
      return true;
    }

    private static object GetApplication(string id)
    {
      object app = null;
      // If the app is already open, get that instance:
      try
      {
        app = System.Runtime.InteropServices.Marshal.GetActiveObject(id);
      }
      catch (System.Runtime.InteropServices.COMException)
      {
      }
      if (app == null)
      {
        app = Activator.CreateInstance(Type.GetTypeFromProgID(id));
      }
      return app;
    }

  }
}
