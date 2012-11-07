@echo off

AltovaXML /xslt1 "MappingMapToSubmissionResults.xslt" /in "C:/google-opennode2/dotnet/prod-opennode2-net/plugins/ICISNPDES_40/docs/Download Result Processing/Rejected_Response_Termination.xml" /out "SubmissionResults.xml" %*
IF ERRORLEVEL 1 EXIT/B %ERRORLEVEL%
