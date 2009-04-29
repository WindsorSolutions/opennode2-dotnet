README FOR PLUGIN BUILD SCRIPTS
===============================

- /WnosPlugin/ant contains folders, ant scripts, and build properties for each plugin.
  Running the default target in /WnosPlugin/ant/<plugin-name>/build.xml creates .jar and zip files in 
  /WnosPlugin/dist/<plugin-name>-source-plugin. Use these scripts if you want to build just one plugin.
  
- The individual scripts will fail unless nodeCommon.jar and nodeLogic.jar exist in /WnosPlugin/resources/lib. 
  These jars must be created by the Node build scripts and placed here.
  
- The targets in /Wnos_Plugin/ant/build.xml apply to all defined plugins - running the default target in
  /Wnos_Plugin/ant/build.xml creates .zip files and checksums for each plugin /WnosPlugin/dist/<plugin-name>-source-plugin.   
    
   