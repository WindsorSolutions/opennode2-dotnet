package com.windsor.node.plugin.icisair.submission;

import java.io.File;
import java.util.Date;
import java.util.Properties;

import javax.persistence.EntityManagerFactory;

import org.junit.Ignore;
import org.junit.Test;
import org.mockito.Mockito;

import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.data.dao.TransactionDao;
import com.windsor.node.plugin.icisair.dao.IcisEntityManagerFactory;
import com.windsor.node.plugin.icisair.dao.IcisWorkflowDao;
import com.windsor.node.plugin.icisair.domain.IcisWorkflow;
import com.windsor.node.service.helper.id.UUIDGenerator;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import com.zaxxer.hikari.HikariConfig;
import com.zaxxer.hikari.HikariDataSource;

public class PerformICISSubmissionTest {
	
	@Ignore
	@Test
	public void testPerform(){
		
	    Properties dsProperties = new Properties();
	    dsProperties.setProperty("dataSource.URL", "jdbc:oracle:thin:opennode2_dev/howlingmad@oracle12c-east.windsor.com:1521:orcleast");
	    //dsProperties.setProperty("dataSource.URL", "jdbc:oracle:thin:ICA_FLOW_LOCAL_USER/memorial@ora11g-win.windsor.com:1521:ORA11G");
	    HikariConfig config = new HikariConfig(dsProperties);
	    config.setDataSourceClassName("oracle.jdbc.pool.OracleDataSource");
	    HikariDataSource dataSource = new HikariDataSource(config);
		
		
		IcisWorkflow icisWorkflow = new IcisWorkflow();
		icisWorkflow.setEtlCompletionDate(new Date());	
		icisWorkflow.setDetectionChangeCompletionDate(new Date());
		IcisWorkflowDao icisWorkflowDao = Mockito.mock(IcisWorkflowDao.class);

		Mockito.when(icisWorkflowDao.findPendingWorkflow()).thenReturn(icisWorkflow);
		Mockito.when(icisWorkflowDao.countPendingWorkflows()).thenReturn(1);
		
		SettingServiceProvider settingServiceProvider = new SettingServiceProvider();
		settingServiceProvider.setTempDir(new File(this.getClass().getProtectionDomain().getCodeSource().getLocation().getPath()));
		settingServiceProvider.setLogDir(new File(this.getClass().getProtectionDomain().getCodeSource().getLocation().getPath()));
		settingServiceProvider.setIdGenerator(new UUIDGenerator());
		
		EntityManagerFactory emf = IcisEntityManagerFactory.initEntityManagerFactory(dataSource);
		TransactionDao transactionDao = Mockito.mock(TransactionDao.class);
		
		PerformICISSubmission performICISSubmission = new PerformICISSubmission();
		performICISSubmission.setIcisWorkflowDao(icisWorkflowDao);
		performICISSubmission.setIdGenerator(new UUIDGenerator());
		performICISSubmission.setSettingService(settingServiceProvider);
		performICISSubmission.setEmf(emf);
		performICISSubmission.setTransactionDao(transactionDao);
		performICISSubmission.setDataSource(dataSource);
		performICISSubmission.getConfigurationArguments().put(AbstractIcisAirSubmission.SERVICE_PARAM_VALIDATE_XML.getName(), "true");
		performICISSubmission.setPluginSourceDir(new File("/home/mbok/windsor/opennode2-java/node-plugin/node-plugin-icis-air/src/main"));
		
		NodeTransaction nodeTransaction = new NodeTransaction();
		DataRequest dataRequest = new DataRequest();
		dataRequest.setType(RequestType.Query);
		nodeTransaction.setRequest(dataRequest);
		performICISSubmission.process(nodeTransaction);
		
	}

}
