package com.windsor.node.plugin.eis12;

import java.io.File;
import java.util.HashMap;
import java.util.Map;
import java.util.Properties;

import org.junit.Ignore;
import org.junit.Test;

import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.DataService;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.common.domain.UserAccount;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.service.helper.id.UUIDGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.zaxxer.hikari.HikariConfig;
import com.zaxxer.hikari.HikariDataSource;

public class EISGetFalicityInvenitoryTest {
	
	
	@Ignore
	@Test
	public void testGetFacilityInventory(){
		
	    Properties dsProperties = new Properties();
	    dsProperties.setProperty("dataSource.URL", "jdbc:sqlserver://sql2008.windsor.com;database=NODE_FLOW_NE;userName=ne-node-user;password=memorial");
	    HikariConfig config = new HikariConfig(dsProperties);
	    config.setDataSourceClassName("com.microsoft.sqlserver.jdbc.SQLServerConnectionPoolDataSource");
	    HikariDataSource dataSource = new HikariDataSource(config);
		
		
		EISGetFacilityInventory eisGetFacilityInventory = new EISGetFacilityInventory();
		NodeTransaction nodeTransaction = new NodeTransaction();
		
		UserAccount userAccount = new UserAccount();
		userAccount.setActive(true);
		userAccount.setNaasUserName("mbok@windsorsolutions.com");
		
		DataService dataService = new DataService();
		dataService.setName("Service name");
		
		Map<String, Object> keyValueMap = new HashMap<String, Object>();
		keyValueMap.put("Emissions Year", "2008");
		keyValueMap.put("Submission Type", "QA");
		
		ByIndexOrNameMap parameters = new ByIndexOrNameMap(keyValueMap);
		
		DataRequest dataRequest = new DataRequest();
		dataRequest.setType(RequestType.Solicit);
		dataRequest.setService(dataService);
		dataRequest.setParameters(parameters);
		
		nodeTransaction.setCreator(userAccount);
		nodeTransaction.setRequest(dataRequest);
		
		SettingServiceProvider settingServiceProvider = new SettingServiceProvider();
		settingServiceProvider.setTempDir(new File(this.getClass().getProtectionDomain().getCodeSource().getLocation().getPath()));
		settingServiceProvider.setLogDir(new File(this.getClass().getProtectionDomain().getCodeSource().getLocation().getPath()));
		settingServiceProvider.setIdGenerator(new UUIDGenerator());
		
		eisGetFacilityInventory.getConfigurationArguments().put(BaseEisXmlPlugin.ARG_ATTACHMENT_PATH, "folder");
		eisGetFacilityInventory.getConfigurationArguments().put(BaseEisXmlPlugin.ARG_AUTHOR_NAME, "Melisa Bok");
		eisGetFacilityInventory.getConfigurationArguments().put(BaseEisXmlPlugin.ARG_ORGANIZATION_NAME, "Windsor");
		eisGetFacilityInventory.getConfigurationArguments().put(BaseEisXmlPlugin.ARG_SENDER_CONTACT_INFO, "melisa_bok@windsorsolutions.com");
		eisGetFacilityInventory.setIdGenerator(new UUIDGenerator());
		eisGetFacilityInventory.setPluginDataSource(dataSource);
		eisGetFacilityInventory.setPluginSourceDir(new File("/home/mbok/windsor/opennode2-java/node-plugin/node-plugin-eis12/src/main/assembly/inner"));
		eisGetFacilityInventory.setSettingService(settingServiceProvider);
		
		eisGetFacilityInventory.process(nodeTransaction);
		
		
	}

}
