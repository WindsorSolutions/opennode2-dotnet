Eclipse configuration files for developing the Windsor Node:
================================================================================

1) windsor_checkstyle_rules.xml: for use with the free, open-source Checkstyle
  static analysis tool (http://checkstyle.sourceforge.net/) and the eclipse-cs 
  plugin (http://eclipse-cs.sourceforge.net/update). The Eclipse projects in 
  this distribution are configured to use Checkstyle. After installing 
  eclipse-cs, select Window/Preferences/Checkstyle, and create a new Global
  Check configuration named Windsor, pointing to this file.

2) windsor_node_code_templates.xml: contains hanges to defaults shipped with 
Eclipse 3.4 (Ganymede). To use this file in Eclipse, select Window/Preferences/
Java/Code Style/Code Templates, click Import, and select the file. Select the 
checkbox labeled "Automatically add comments for new methods and 
types," and click Apply.

Our modifications include:
- The "Files" comment includes the BSD license at the top of every new .java 
  file. 
  
  
