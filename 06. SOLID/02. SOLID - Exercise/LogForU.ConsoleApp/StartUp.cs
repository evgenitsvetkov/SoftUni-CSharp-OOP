
using LogForU.ConsoleApp.CustomLayouts;
using LogForU.Core.Appenders;
using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.IO;
using LogForU.Core.IO.Interfaces;
using LogForU.Core.Layouts;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Loggers;
using LogForU.Core.Loggers.Interfaces;

ILayout xmlLayout = new XmlLayout();
IAppender consoleAppender = new ConsoleAppender(xmlLayout);

ILogFile logFile = new LogFile();
IAppender fileAppender = new FileAppender(xmlLayout, logFile);  

ILogger logger = new Logger(consoleAppender, fileAppender);
logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");


//logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
//logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
//logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
//logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
//logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");
