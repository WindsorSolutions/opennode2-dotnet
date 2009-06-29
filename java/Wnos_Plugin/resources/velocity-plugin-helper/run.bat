@ECHO OFF

:: Set path to the Java SDK 1.4.2 bin dir
set JDK=%JAVA_HOME%



:: =========================================================
:: DO NOT EDIT BELOW THIS LINE
:: =========================================================
set PATH=%PATH%;%JDK%
set CLASSPATH=.;..;conf
set CLASSPATH=%CLASSPATH%;lib\velocity-plugin-helper.jar
set CLASSPATH=%CLASSPATH%;lib\commons-beanutils-1.8.0.jar
set CLASSPATH=%CLASSPATH%;lib\commons-beanutils-bean-collections-1.8.0.jar
set CLASSPATH=%CLASSPATH%;lib\commons-beanutils-core-1.8.0.jar
set CLASSPATH=%CLASSPATH%;lib\commons-codec-1.3.jar
set CLASSPATH=%CLASSPATH%;lib\commons-collections-3.2.1.jar
set CLASSPATH=%CLASSPATH%;lib\commons-dbcp-1.2.2.jar
set CLASSPATH=%CLASSPATH%;lib\commons-digester-1.8.jar
set CLASSPATH=%CLASSPATH%;lib\commons-discovery-0.4.jar
set CLASSPATH=%CLASSPATH%;lib\commons-httpclient-3.1.jar
set CLASSPATH=%CLASSPATH%;lib\commons-io-1.4.jar
set CLASSPATH=%CLASSPATH%;lib\commons-javaflow.jar
set CLASSPATH=%CLASSPATH%;lib\commons-lang-2.4.jar
set CLASSPATH=%CLASSPATH%;lib\commons-logging-1.1.1.jar
set CLASSPATH=%CLASSPATH%;lib\commons-logging-adapters-1.1.1.jar
set CLASSPATH=%CLASSPATH%;lib\commons-pool-1.4.jar
set CLASSPATH=%CLASSPATH%;lib\commons-validator-1.3.1.jar
set CLASSPATH=%CLASSPATH%;lib\jug-asl-2.0.0.jar
set CLASSPATH=%CLASSPATH%;lib\junit.jar
set CLASSPATH=%CLASSPATH%;lib\log4j-1.2.15.jar
set CLASSPATH=%CLASSPATH%;lib\mail.jar
set CLASSPATH=%CLASSPATH%;lib\mysql-connector-java-5.0.8-bin.jar
set CLASSPATH=%CLASSPATH%;lib\net-monitor-0.1.jar
set CLASSPATH=%CLASSPATH%;lib\ojdbc14_g.jar
set CLASSPATH=%CLASSPATH%;lib\spring-2.5.5.jar
set CLASSPATH=%CLASSPATH%;lib\sqljdbc.jar
set CLASSPATH=%CLASSPATH%;lib\velocity-1.6.2.jar
set CLASSPATH=%CLASSPATH%;lib\velocity-1.6.2-dep.jar
set CLASSPATH=%CLASSPATH%;lib\db2jcc_license_cu.jar
set CLASSPATH=%CLASSPATH%;lib\db2jcc.jar


java -classpath %CLASSPATH%  com.windsor.node.plugin.common.velocity.ConsoleVelocityHelper "conf/context_config.xml"


:: DONE
echo DONE