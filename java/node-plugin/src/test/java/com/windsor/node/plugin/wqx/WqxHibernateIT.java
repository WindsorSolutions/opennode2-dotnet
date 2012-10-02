package com.windsor.node.plugin.wqx;

import static org.testng.Assert.assertEquals;
import static org.testng.Assert.assertTrue;

import java.util.List;

import org.testng.annotations.Test;

import com.windsor.node.plugin.wqx.domain.generated.ActivityDataType;
import com.windsor.node.plugin.wqx.domain.generated.ActivityDescriptionDataType;
import com.windsor.node.plugin.wqx.domain.generated.MonitoringLocationDataType;
import com.windsor.node.plugin.wqx.domain.generated.MonitoringLocationGeospatialDataType;
import com.windsor.node.plugin.wqx.domain.generated.MonitoringLocationIdentityDataType;
import com.windsor.node.plugin.wqx.domain.generated.OrganizationDataType;
import com.windsor.node.plugin.wqx.domain.generated.ProjectDataType;
import com.windsor.node.plugin.wqx.domain.generated.ResultDataType;

/**
 * WQX Hibernate integration tests.
 *
 */
public class WqxHibernateIT extends AbstractWqxIT {

	@Test(groups = WQX_TEST_GROUP_NAME)
	public void organizationTest() {
		final List<OrganizationDataType> list = getEntityManager().createQuery(
				"select x from OrganizationDataType x", OrganizationDataType.class).getResultList();
		assertEquals(list.size(), 1);
		final OrganizationDataType org = list.get(0);
		assertEquals(org.getDbid(), "32559EDA-8FEF-45FD-B126-C921CCEF796B");
		assertEquals(org.getOrganizationDescription().getOrganizationFormalName(),
				"State of XYZ Department of Environmental Quality",
				"organization description equality");
		assertEquals(org.getOrganizationDescription().getOrganizationIdentifier(), "XYZ_Watershed");
		assertEquals(org.getOrganizationDescription().getTribalCode(), "ABC");
		assertEquals(org.getOrganizationDescription().getOrganizationDescriptionText(), "Org Desc");

		final List<ProjectDataType> projects = org.getProject();
		assertEquals(list.size(), 1);
		final ProjectDataType project = projects.get(0);
		assertEquals(project.getDbid(), "BF14F554-9BCC-47D1-9926-227CCB6E012F");

		final List<ActivityDataType> activities = org.getActivity();
		assertEquals(activities.size(), 1);
		final ActivityDataType activity = activities.get(0);
		assertEquals(activity.getDbid(), "001438C7-C677-4085-8498-E7ED5DAE1038");

		final List<MonitoringLocationDataType> monitoringLocations = org.getMonitoringLocation();
		assertEquals(monitoringLocations.size(), 1);
		final MonitoringLocationDataType monitoringLocation = monitoringLocations.get(0);
		assertEquals(monitoringLocation.getDbid(), "00209502-7E0C-4C36-AA8A-5FA4E2BB6C71");
	}

	@Test(groups = WQX_TEST_GROUP_NAME)
	public void projectTest() {
		final List<ProjectDataType> list = getEntityManager().createQuery(
				"select x from ProjectDataType x", ProjectDataType.class).getResultList();
		assertEquals(list.size(), 1);
		final ProjectDataType project = list.get(0);
		assertEquals(project.getDbid(), "BF14F554-9BCC-47D1-9926-227CCB6E012F");
		assertEquals(project.getProjectIdentifier(), "Surface Water Assessment");
		assertEquals(
				project.getProjectName(),
				"State of XYZ, Department of Environmental Quality, Water Quality Division, Surface Water Assessment");
		assertEquals(
				project.getProjectDescriptionText(),
				"The WXYZ Surface Water Assessment Project entails the collection of scientifically-sound water quality monitoring data using established collection methods, and assessing those data in a consistent manner.");
		assertEquals(project.getSamplingDesignTypeCode(), "ABC");
		assertEquals(project.getQAPPApprovedIndicator(), "Y");
		assertEquals(project.getQAPPApprovalAgencyName(), "XYZ Agency Name");

		// add data and test for project.getProjectMonitoringLocationWeighting()
	}

	@Test(groups = WQX_TEST_GROUP_NAME)
	public void monitoringLocationTest() {
		final List<MonitoringLocationDataType> list = getEntityManager().createQuery(
				"select x from MonitoringLocationDataType x", MonitoringLocationDataType.class)
				.getResultList();
		assertEquals(list.size(), 1);
		final MonitoringLocationDataType ml = list.get(0);
		final MonitoringLocationIdentityDataType ident = ml.getMonitoringLocationIdentity();
		final MonitoringLocationGeospatialDataType geo = ml.getMonitoringLocationGeospatial();
		assertEquals(ml.getDbid(), "00209502-7E0C-4C36-AA8A-5FA4E2BB6C71");

		/*
		 * location identity
		 */
		assertEquals(ident.getMonitoringLocationIdentifier(), "WB255");
		assertEquals(ident.getMonitoringLocationName(), "WB255 - BEAR CREEK - BELOW HIGHWAY 230");
		assertEquals(ident.getMonitoringLocationTypeName(), "Stream");
		assertEquals(ident.getMonitoringLocationDescriptionText(), "Description text");
		assertEquals(ident.getTribalLandName(), "Tribal Land Name");
		assertTrue(ident.isSetTribalLandIndicator());
		assertEquals(ident.getHUCEightDigitCode(), "10180002");
		assertEquals(ident.getHUCTwelveDigitCode(), "101800020305");

		/*
		 * geospatial
		 */
		assertEquals(geo.getLatitudeMeasure(), "41.1171964");
		assertEquals(geo.getLongitudeMeasure(), "-106.5275892");
		assertEquals(geo.getHorizontalCollectionMethodName(), "GPSUNS");
		assertEquals(geo.getHorizontalCoordinateReferenceSystemDatumName(), "WGS84");

		/*
		 * well info
		 */

		// FIXME: source map scale
		// FIXME: horizontal accuracy measure
		// FIXME: horizontal accuracy measure unit
		// FIXME: vertical measure
		// FIXME: vertical measure unit
		// FIXME: vertical collection measure
		// FIXME: vertical coordinate ref system datum
		// FIXME: country code
		// FIXME: state code
		// FIXME: county code
		// FIXME: well type
		// FIXME: formation type
		// FIXME: well hole depth measure
		// FIXME: well hole depth measure unit

	}

	@Test(groups = WQX_TEST_GROUP_NAME)
	public void activityTest() {
		final List<ActivityDataType> list = getEntityManager().createQuery(
				"select x from ActivityDataType x", ActivityDataType.class).getResultList();
		assertEquals(list.size(), 1);
		final ActivityDataType activity = list.get(0);

		assertEquals(activity.getDbid(), "001438C7-C677-4085-8498-E7ED5DAE1038");

		final ActivityDescriptionDataType description = activity.getActivityDescription();
		assertEquals(description.getActivityIdentifier(), "C1569-0");

		// FIXME: other fields

	}

	@Test(groups = WQX_TEST_GROUP_NAME)
	public void resultTest() {
		final List<ResultDataType> list = getEntityManager().createQuery(
				"select x from ResultDataType x", ResultDataType.class).getResultList();
		assertEquals(list.size(), 6);

		// FIXME: other fields
	}

}
