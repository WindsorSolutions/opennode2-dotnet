CP=${CLASSPATH}

# Set path to the Java SDK (5 or higher)
JDK=${JAVA_HOME}
CP=${CP}:${JDK};

# add folders to path
CP=${CP}:conf;

# Set path to all the jars in lib
for lib in lib/*.jar; do
    CP=${CP}:${lib};
done

#for lib in bin/*.jar; do
#    CP=${CP}:${lib};
#done


# Set main
MAINCLASS=com.windsor.node.plugin.common.velocity.ConsoleVelocityHelper

# Go
${JDK}/bin/java -classpath ${CP} ${MAINCLASS} "conf/context_config.xml"