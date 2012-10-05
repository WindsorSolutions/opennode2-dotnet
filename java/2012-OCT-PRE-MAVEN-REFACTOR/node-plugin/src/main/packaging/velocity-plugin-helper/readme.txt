================================================================================

USING THE VELOCITY PLUGIN HELPER CONSOLE TOOLS:
================================================================================

1) Edit conf/helper.properties to point to your Velocity template and output 
    file, and to configure any optional arguments for the template or db 
    queries.
    
2)  Edit conf/jdbc.properties to set up your database connection.

3) Make sure you have an environment variable named JAVA_HOME that points to 
    a valid Java runtime environment or JDK.
    
4) Invoke run.bat (Windows) or run.sh (Linux/Unix).

5) conf/log4j.properties is set up to write to the console, but can also be set 
    up to write to a file.
    
6) The "api" folder contains JavaDocs with details on the full programming 
    interface. 

================================================================================

USEFUL TEMPLATE TRICKS:
================================================================================

1) See the JavaDocs for JdbcTemlpateHelper for the query API.

2) You can output any debugging text to the console:
    
    $helper.print("Starting the query...")
    
    This includes template variable (including those set in the 
    helper.properties file):
    
    $helper.print($changeDate)


3) The helper includes a StopWatch, so you can time operations 

    $helper.startStopWatch()    # start timing
                                # loop over a query
    $helper.stopStopWatch()     # stop timing
    $helper.print("Total Time:")
    $helper.printElapsedTime()
      