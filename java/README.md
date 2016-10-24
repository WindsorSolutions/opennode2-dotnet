# OpenNode 2 Java

This is the project for the Java version of the OpenNode 2 product. This project contains both the OpenNode 2 
application itself as well as all of the plugins developed for OpenNode 2. Keeping the plugins in the same repository
as the product ensures that the plugins will at least compile against the current version of ON2.

## Building

The project uses Maven to manage the project, build artifacts, etc. By default Maven will build the product with the 
"development" profile, meaning that the log files will be as informative as possible. To build the project, simply
invoke Maven in the project's top-level directory.

    mvn clean install
    
To build a version suitable for production deployment, tell Maven to use the production profile.

    mvn -Pprod clean install
    
    