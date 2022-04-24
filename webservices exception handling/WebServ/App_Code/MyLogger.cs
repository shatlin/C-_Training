using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using System.Diagnostics;

/// <summary>
/// Summary description for MyLogger
/// </summary>
public class ErrorLogger
{
    static readonly LogWriter _writer;
    static ErrorLogger()
    {
        // The formatter is responsible for the
        // look of the message. Notice the tokens:
        // {timestamp}, {newline}, {message}, {category}
        TextFormatter formatter = new TextFormatter
            ("Timestamp: {timestamp}{newline}" +
            "Message: {message}{newline}" +
            "Category: {category}{newline}");

        // Log messages to a log file.
        // Use the formatter mentioned above
        // as well as the header and footer
        // specified.
        FlatFileTraceListener logFileListener =
            new FlatFileTraceListener("c:\\messages.log",
                                       "",
                                       "------------------------------------------------------------------------------------------",
                                       formatter);

        // My collection of TraceListeners.
        // I am only using one.  Could add more.
        LogSource mainLogSource =
            new LogSource("MainLogSource", SourceLevels.All);
        mainLogSource.Listeners.Add(logFileListener);

        // Assigning a non-existant LogSource
        // for Logging Application Block
        // Specials Sources I don't care about.
        // Used to say "don't log".
        LogSource nonExistantLogSource = new LogSource("Empty");

        // I want all messages with a category of
        // "Error" or "Debug" to get distributed
        // to all TraceListeners in my mainLogSource.
        IDictionary<string, LogSource> traceSources = new Dictionary<string, LogSource>();
        traceSources.Add("Error", mainLogSource);
        traceSources.Add("Debug", mainLogSource);

        // Let's glue it all together.
        // No filters at this time.
        // I won't log a couple of the Special
        // Sources: All Events and Events not
        // using "Error" or "Debug" categories.
        _writer = new LogWriter(new ILogFilter[0],
                        traceSources,
                        nonExistantLogSource,
                        nonExistantLogSource,
                        mainLogSource,
                        "Error",
                        false,
                        true);
    }

    /// 
    /// Writes an Error to the log.
    /// 
    /// Error Message
    public static void Write(string message)
    {
        Write(message, "Error");
    }

    /// 
    /// Writes a message to the log using the specified
    /// category.
    /// 
    /// 
    /// 
    public static void Write(string message, string category)
    {
        LogEntry entry = new LogEntry();
        entry.Categories.Add(category);
        entry.Message = message;
        _writer.Write(entry);
    }

}
