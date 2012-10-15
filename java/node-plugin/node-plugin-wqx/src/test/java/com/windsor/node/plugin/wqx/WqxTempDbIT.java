package com.windsor.node.plugin.wqx;

import static org.testng.Assert.assertEquals;
import static org.testng.Assert.assertNotNull;
import static org.testng.Assert.assertTrue;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URISyntaxException;
import java.util.GregorianCalendar;
import java.util.List;

import javax.persistence.TypedQuery;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;
import javax.xml.bind.JAXBException;
import javax.xml.parsers.ParserConfigurationException;

import org.xml.sax.SAXException;

import com.windsor.node.plugin.test.XmlUtils;
import com.windsor.node.plugin.wqx.domain.generated.ActivityDataType;
import com.windsor.node.plugin.wqx.domain.generated.ActivityDescriptionDataType;
import com.windsor.node.plugin.wqx.domain.generated.ActivityLocationDataType;
import com.windsor.node.plugin.wqx.domain.generated.MonitoringLocationDataType;
import com.windsor.node.plugin.wqx.domain.generated.MonitoringLocationGeospatialDataType;
import com.windsor.node.plugin.wqx.domain.generated.MonitoringLocationIdentityDataType;
import com.windsor.node.plugin.wqx.domain.generated.OrganizationDataType;
import com.windsor.node.plugin.wqx.domain.generated.OrganizationDataType_;
import com.windsor.node.plugin.wqx.domain.generated.OrganizationDescriptionDataType;
import com.windsor.node.plugin.wqx.domain.generated.ProjectDataType;
import com.windsor.node.plugin.wqx.domain.generated.ResultDataType;

/**
 * WQX Hibernate integration tests.
 *
 */
public class WqxTempDbIT extends AbstractWqxTempDbIT {

	/**
	 * Path to the test XML file, relative to the classpath.
	 */
	private static final String XML_PATH = "/" + TEST_XML + "/wqx-1.xml";

	public void marshalTest() throws JAXBException, SAXException, URISyntaxException, IOException, ParserConfigurationException {
		final String xml = WqxTestUtil.validateXml(getEntityManager());
		final InputStream is1 = getClass().getResourceAsStream(XML_PATH);
		final InputStream is2 = new ByteArrayInputStream(xml.getBytes("UTF-8"));
		assertTrue(XmlUtils.equals(is1, is2), "Check that the marshalled XML document matches the expected XML document");
	}

	public void organizationTest() {
		final List<OrganizationDataType> list = getEntityManager().createQuery(
				"select x from OrganizationDataType x", OrganizationDataType.class).getResultList();
		assertEquals(list.size(), 1);
		final OrganizationDataType org = list.get(0);
		assertEquals(org.getDbid(), "32559EDA-8FEF-45FD-B126-C921CCEF796B");

		organizationDescriptionTest(org.getOrganizationDescription());

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

	private void organizationDescriptionTest(
			final OrganizationDescriptionDataType organizationDescription) {
		assertEquals(organizationDescription.getOrganizationFormalName(),
				"State of XYZ Department of Environmental Quality",
				"organization description equality");
		assertEquals(organizationDescription.getOrganizationIdentifier(), "XYZ_Watershed");
		assertEquals(organizationDescription.getTribalCode(), "ABC");
		assertEquals(organizationDescription.getOrganizationDescriptionText(), "Org Desc");
	}

	public void projectTest() {
		final List<ProjectDataType> list = getEntityManager().createQuery(
				"select x from ProjectDataType x", ProjectDataType.class).getResultList();
		assertEquals(list.size(), 1);
		final ProjectDataType project = list.get(0);
		assertEquals(project.getDbid(), "BF14F554-9BCC-47D1-9926-227CCB6E012F");
		assertEquals(project.getOrganizationId(), "32559EDA-8FEF-45FD-B126-C921CCEF796B");
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

	public void monitoringLocationTest() {
		final List<MonitoringLocationDataType> list = getEntityManager().createQuery(
				"select x from MonitoringLocationDataType x", MonitoringLocationDataType.class)
				.getResultList();
		assertEquals(list.size(), 1);
		final MonitoringLocationDataType ml = list.get(0);
		final MonitoringLocationIdentityDataType ident = ml.getMonitoringLocationIdentity();
		final MonitoringLocationGeospatialDataType geo = ml.getMonitoringLocationGeospatial();
		assertEquals(ml.getDbid(), "00209502-7E0C-4C36-AA8A-5FA4E2BB6C71");
		assertEquals(ml.getOrganizationId(), "32559EDA-8FEF-45FD-B126-C921CCEF796B");

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

	public void activityTest() {
		final List<ActivityDataType> list = getEntityManager().createQuery(
				"select x from ActivityDataType x", ActivityDataType.class).getResultList();
		assertEquals(list.size(), 1);
		final ActivityDataType activity = list.get(0);

		assertEquals(activity.getDbid(), "001438C7-C677-4085-8498-E7ED5DAE1038");
		assertEquals(activity.getOrganizationId(), "32559EDA-8FEF-45FD-B126-C921CCEF796B");

		final ActivityDescriptionDataType description = activity.getActivityDescription();
		assertEquals(description.getActivityIdentifier(), "C1569-0");
		assertEquals(description.getActivityTypeCode(), "Routine Sample");
		assertEquals(description.getActivityMediaName(), "Water");
		assertEquals(description.getActivityMediaSubdivisionName(), "Subdivision");
		assertEquals(description.getActivityStartDate(),
				new GregorianCalendar(2007, 9, 2).getTime());
		assertEquals(description.getActivityStartTime().getTime(), "11:15:00.0000000");
		assertEquals(description.getActivityStartTime().getTimeZoneCode(), "MDT");
		assertEquals(description.getActivityEndDate(), new GregorianCalendar(2007, 10, 2).getTime());
		assertEquals(description.getActivityEndTime().getTime(), "12:15:00");
		assertEquals(description.getActivityEndTime().getTimeZoneCode(), "EST");
		assertEquals(description.getActivityRelativeDepthName(), "RDN");
		assertEquals(description.getActivityDepthHeightMeasure().getMeasureValue(), "1.01");
		assertEquals(description.getActivityDepthHeightMeasure().getMeasureUnitCode(), "CM");

		assertEquals(description.getActivityTopDepthHeightMeasure().getMeasureValue(), "2.02");
		assertEquals(description.getActivityTopDepthHeightMeasure().getMeasureUnitCode(), "IN");

		assertEquals(description.getActivityBottomDepthHeightMeasure().getMeasureValue(), "3.03");
		assertEquals(description.getActivityBottomDepthHeightMeasure().getMeasureUnitCode(), "FT");

		assertEquals(description.getActivityDepthAltitudeReferencePointText(), "4.04");
		assertEquals(description.getMonitoringLocationIdentifier(), "WHP0049");

		assertEquals(description.getActivityCommentText(), "Activity Comment");
		final ActivityLocationDataType location = activity.getActivityLocation();
		assertEquals(location.getLatitudeMeasure(), "42.3250");
		assertEquals(location.getLongitudeMeasure(), "72.6417");

		assertEquals(location.getSourceMapScaleNumeric(), new Integer(1));
		assertEquals(location.getHorizontalAccuracyMeasure().getMeasureValue(), "5.05");
		assertEquals(location.getHorizontalAccuracyMeasure().getMeasureUnitCode(), "MI");
		assertEquals(location.getHorizontalCollectionMethodName(), "MAN");
		assertEquals(location.getHorizontalCoordinateReferenceSystemDatumName(), "STD");

		// FIXME: other fields

	}

	public void metamodelTest() {
		final CriteriaBuilder builder = getEntityManager().getCriteriaBuilder();
		final CriteriaQuery<OrganizationDataType> query = builder
				.createQuery(OrganizationDataType.class);
		final Root<OrganizationDataType> root = query.from(OrganizationDataType.class);
		final Predicate condition = builder.equal(root.get(OrganizationDataType_.dbid),
				"32559EDA-8FEF-45FD-B126-C921CCEF796B");
		query.where(condition);
		final TypedQuery<OrganizationDataType> tq = getEntityManager().createQuery(query);
		final OrganizationDataType org = tq.getSingleResult();
		assertNotNull(org);
	}

	public void resultTest() {
		final List<ResultDataType> list = getEntityManager().createQuery(
				"select x from ResultDataType x", ResultDataType.class).getResultList();
		assertEquals(list.size(), 6);

		// FIXME: other fields
	}

}
