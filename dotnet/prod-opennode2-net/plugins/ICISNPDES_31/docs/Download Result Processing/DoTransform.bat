@echo off

AltovaXML /xslt1 "MappingMapToSubmissionResults.xslt" /in "AllResponseXMLsCheck.xml" /out "SubmissionResults.xml" %*
IF ERRORLEVEL 1 EXIT/B %ERRORLEVEL%
