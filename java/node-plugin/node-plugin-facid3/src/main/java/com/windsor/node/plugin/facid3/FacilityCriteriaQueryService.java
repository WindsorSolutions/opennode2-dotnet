package com.windsor.node.plugin.facid3;

import static com.windsor.node.plugin.common.IterableUtils.toIterable;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import javax.persistence.EntityManager;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Join;
import javax.persistence.criteria.Path;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import com.windsor.node.plugin.common.AbstractTransformer;
import com.windsor.node.plugin.common.IterableUtils;
import com.windsor.node.plugin.common.persistence.AbstractCriteriaFactory;
import com.windsor.node.plugin.common.persistence.CriteriaFactory;
import com.windsor.node.plugin.common.persistence.QueryUtils;
import com.windsor.node.plugin.facid3.domain.AbstractQueryableFacilityDataType;
import com.windsor.node.plugin.facid3.domain.AbstractQueryableFacilityDataType_;
import com.windsor.node.plugin.facid3.domain.GeographicLocation;
import com.windsor.node.plugin.facid3.domain.GeographicLocation_;
import com.windsor.node.plugin.facid3.domain.generated.AlternativeNameDataType;
import com.windsor.node.plugin.facid3.domain.generated.AlternativeNameDataType_;
import com.windsor.node.plugin.facid3.domain.generated.EnvironmentalInterestDataType;
import com.windsor.node.plugin.facid3.domain.generated.EnvironmentalInterestDataType_;
import com.windsor.node.plugin.facid3.domain.generated.FacilityDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityNAICSDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityNAICSDataType_;
import com.windsor.node.plugin.facid3.domain.generated.FacilityPrimaryGeographicLocationDescriptionDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilityPrimaryGeographicLocationDescriptionDataType_;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySICDataType;
import com.windsor.node.plugin.facid3.domain.generated.FacilitySICDataType_;

/**
 * Service for querying for {@link AbstractQueryableFacilityDataType}-related
 * objects based on a {@link Map} of criteria parameters.
 *
 */
public class FacilityCriteriaQueryService {

	/**
	 * Map of parameter names to criteria factories for creating the where
	 * clause.
	 */
	private static final Map<String, Class<? extends CriteriaFactory<?, AbstractQueryableFacilityDataType>>> CRITERIA_FACTORIES = new HashMap<String, Class<? extends CriteriaFactory<?, AbstractQueryableFacilityDataType>>>();

	/**
	 * Initializes the criteria factories map.
	 */
	static {
		CRITERIA_FACTORIES.put(
				BaseFacIdGetFacilityService.STANDARD_ENVIRONMENTAL_INTEREST_TYPE.getName(),
				StandardEnvironmentalInterestTypeCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.ZIP_CODE.getName(),
				ZipCodeCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.TRIBAL_LAND_CODE.getName(),
				TribalLandCodeCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.FEDERAL_FACILITY.getName(),
				FederalFacilityCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.FACILITY_NAME.getName(),
				NameCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.SIC_CODE.getName(),
				SicCodeCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.NAICS_CODE.getName(),
				NaicsCodeCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.CITY_NAME.getName(),
				CityNameCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.STATE.getName(),
				StateCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.COUNTY_NAME.getName(),
				CountyNameCriteriaFactory.class);
		// CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.BOUNDING.getName(),
		// BoundingCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.CHANGE_DATE.getName(),
				ChangeDateCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.FACILITY_SITE_IDENTIFIER.getName(),
				FacilitySiteIdentifierCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.ORIGINATING_PARTNER_NAME.getName(),
				OriginatingPartnerNameCriteriaFactory.class);
		CRITERIA_FACTORIES.put(BaseFacIdGetFacilityService.INFO_SYSTEM_ACORNYM_NAME.getName(),
				InformationSystemAcronymNameCriteriaFactory.class);
	}

	/*
	 * {@link EntityManager} to use for building and executing the query.
	 */
	private final EntityManager entityManager;

	/**
	 * Constructor.
	 *
	 * @param entityManager
	 *            {@link EntityManager} to use to build and execute the query
	 */
	public FacilityCriteriaQueryService(final EntityManager entityManager) {
		this.entityManager = entityManager;
	}

	/**
	 * Returns a list of where-clauses to be and-ed together by the caller.
	 *
	 * @param query
	 *            {@CriteriaQuery} to use when constructing the
	 *            where-clause
	 * @param cb
	 *            {@link CriteriaBuilder} to use for creating the query
	 * @param root
	 *            {@link Root} of the query
	 * @param parameters
	 *            {@link Map} of parameters to use for constructing the
	 *            where-clause of the query
	 * @return list of where-clauses
	 */
	private Collection<Predicate> createPredicates(final CriteriaQuery<?> query,
			final CriteriaBuilder cb, final Root<? extends AbstractQueryableFacilityDataType> root,
			final Map<String, Object> parameters) {
		final Collection<Predicate> predicates = new ArrayList<Predicate>();
		for (final Entry<String, Object> entry : parameters.entrySet()) {
			final Class<? extends CriteriaFactory<?, AbstractQueryableFacilityDataType>> criteriaFactoryClass = CRITERIA_FACTORIES
					.get(entry.getKey());
			CriteriaFactory<?, AbstractQueryableFacilityDataType> criteriaFactory = null;
			if (criteriaFactoryClass != null) {
				try {
					criteriaFactory = criteriaFactoryClass.newInstance();
				} catch (final InstantiationException e) {
					throw new RuntimeException(e);
				} catch (final IllegalAccessException e) {
					throw new RuntimeException(e);
				}
				criteriaFactory.setUntypedData(entry.getValue());
				predicates.add(criteriaFactory.create(root, query, cb));
			}
		}
		return predicates;
	}

	/**
	 * Returns a distinct list of {@link AbstractQueryableFacilityDataType}
	 * objects which match the {@code parameters}.
	 *
	 * @param queryType
	 *            type of objects which will be returned in the list
	 * @param parameters
	 *            {@link Map} of values for constructing the where-clause of the
	 *            query
	 * @return distinct list of {@link AbstractQueryableFacilityDataType}
	 *         objects which match the {@code parameters}
	 */
	public <T extends AbstractQueryableFacilityDataType> List<T> getDistinctResultList(
			final Class<T> queryType, final Map<String, Object> parameters) {
		final CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		final CriteriaQuery<T> query = cb.createQuery(queryType);
		final Root<T> root = query.from(queryType);
		query.distinct(true);
		final Collection<Predicate> predicates = createPredicates(query, cb, root, parameters);
		query.where(predicates.toArray(new Predicate[predicates.size()]));
		return getEntityManager().createQuery(query).getResultList();
	}

	/**
	 * Returns the count of facilities which match the {@code parameters}.
	 *
	 * @param parameters
	 *            {@link Map} of values for constructing the where-clause of the
	 *            query
	 * @return the count of facilities which match the {@code parameters}
	 */
	public long getDistinctCount(final Map<String, Object> parameters) {
		final CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		final CriteriaQuery<Long> query = cb.createQuery(Long.class);
		final Root<FacilityDataType> root = query.from(FacilityDataType.class);
		query.select(cb.countDistinct(root));
		final Collection<Predicate> predicates = createPredicates(query, cb, root, parameters);
		query.where(predicates.toArray(new Predicate[predicates.size()]));
		return getEntityManager().createQuery(query).getSingleResult();
	}

	/**
	 * Returns the {@link EntityManager} for creating the query.
	 *
	 * @return the {@link EntityManager} for creating the query
	 */
	private EntityManager getEntityManager() {
		return entityManager;
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's environmental interest type.
	 *
	 */
	static class StandardEnvironmentalInterestTypeCriteriaFactory extends
			AbstractCriteriaFactory<List<String>, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			final Join<?, EnvironmentalInterestDataType> environmentalInterest = root
					.join(AbstractQueryableFacilityDataType_.environmentalInterests);
			return QueryUtils.startsWithIgnoreCase(getData(), cb, environmentalInterest
					.get(EnvironmentalInterestDataType_.environmentalInterestTypeText));
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's zip code.
	 *
	 */
	static class ZipCodeCriteriaFactory extends
			AbstractCriteriaFactory<List<String>, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			final AbstractTransformer.LengthTransformer lengthTransformer = new AbstractTransformer.LengthTransformer(
					5);

			return QueryUtils.createLike(IterableUtils.transform(getData(), lengthTransformer), cb,
					toIterable(root.get(AbstractQueryableFacilityDataType_.zipCode)));
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's tribal code.
	 *
	 */
	static class TribalLandCodeCriteriaFactory extends
			AbstractCriteriaFactory<String, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			return cb.equal(
					cb.upper(root.get(AbstractQueryableFacilityDataType_.tribalLandIndicator)),
					getData().toUpperCase());
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's federal facility indicator.
	 *
	 */
	static class FederalFacilityCriteriaFactory extends
			AbstractCriteriaFactory<String, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			return cb
					.equal(cb.upper(root
							.get(AbstractQueryableFacilityDataType_.federalFacilityIndicator)),
							getData());
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's name.
	 *
	 */
	static class NameCriteriaFactory extends
			AbstractCriteriaFactory<String, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			final Join<?, AlternativeNameDataType> join = root
					.join(AbstractQueryableFacilityDataType_.alternativeNames);
			return cb.or(
					QueryUtils.startsWithIgnoreCase(getData(), cb,
							root.get(AbstractQueryableFacilityDataType_.facilityName)),
					QueryUtils.startsWithIgnoreCase(getData(), cb,
							join.get(AlternativeNameDataType_.alternativeNameText)));
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's SIC codes.
	 *
	 */
	static class SicCodeCriteriaFactory extends
			AbstractCriteriaFactory<List<String>, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			final Join<?, FacilitySICDataType> join1 = root
					.join(AbstractQueryableFacilityDataType_.sicCodes);
			final Join<?, EnvironmentalInterestDataType> join2 = root
					.join(AbstractQueryableFacilityDataType_.environmentalInterests);
			final Join<?, FacilitySICDataType> join3 = join2
					.join(EnvironmentalInterestDataType_.sicCodes);

			return cb.or(
					QueryUtils.startsWithIgnoreCase(getData(), cb,
							join1.get(FacilitySICDataType_.SICCode)),
					QueryUtils.startsWithIgnoreCase(getData(), cb,
							join3.get(FacilitySICDataType_.SICCode)));
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's NAICS codes.
	 *
	 */
	static class NaicsCodeCriteriaFactory extends
			AbstractCriteriaFactory<List<String>, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			final Join<?, FacilityNAICSDataType> facilityNaicsCodes = root
					.join(AbstractQueryableFacilityDataType_.naicsCodes);
			final Join<?, EnvironmentalInterestDataType> envInt = root
					.join(AbstractQueryableFacilityDataType_.environmentalInterests);
			final Join<?, FacilityNAICSDataType> envIntNaicsCodes = envInt
					.join(EnvironmentalInterestDataType_.naicsCodes);
			return cb.or(QueryUtils.startsWithIgnoreCase(getData(), cb,
					toIterable(facilityNaicsCodes.get(FacilityNAICSDataType_.facilityNAICSCode))),
					QueryUtils.startsWithIgnoreCase(getData(), cb, toIterable(envIntNaicsCodes
							.get(FacilityNAICSDataType_.facilityNAICSCode))));
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's state.
	 *
	 */
	static class StateCriteriaFactory extends
			AbstractCriteriaFactory<List<String>, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			return QueryUtils.inIgnoreCase(getData(), cb,
					root.get(AbstractQueryableFacilityDataType_.state));
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's city.
	 *
	 */
	static class CityNameCriteriaFactory extends
			AbstractCriteriaFactory<List<String>, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			return QueryUtils.inIgnoreCase(getData(), cb,
					root.get(AbstractQueryableFacilityDataType_.city));
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's county.
	 *
	 */
	static class CountyNameCriteriaFactory extends
			AbstractCriteriaFactory<List<String>, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			return QueryUtils.inIgnoreCase(getData(), cb,
					root.get(AbstractQueryableFacilityDataType_.county));
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's latitude and longitude.
	 *
	 */
	static class BoundingCriteriaFactory extends
			AbstractCriteriaFactory<BoundingCoordinates, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			final Join<?, FacilityPrimaryGeographicLocationDescriptionDataType> join = root
					.join(AbstractQueryableFacilityDataType_.location);
			final Path<GeographicLocation> location = join
					.get(FacilityPrimaryGeographicLocationDescriptionDataType_.geographicLocation);
			final Path<Double> latitude = location.get(GeographicLocation_.latitude);
			final Path<Double> longitude = location.get(GeographicLocation_.longitude);
			return cb.and(cb.lessThanOrEqualTo(latitude, getData().getNorthLatitude()), //
					cb.greaterThanOrEqualTo(latitude, getData().getSouthLatitude()), //
					cb.lessThanOrEqualTo(longitude, getData().getWestLongitude()), //
					cb.greaterThanOrEqualTo(longitude, getData().getEastLongitude()));
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the the
	 * last time the facility's data was updated.
	 *
	 */
	static class ChangeDateCriteriaFactory extends
			AbstractCriteriaFactory<Date, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			return cb.greaterThanOrEqualTo(
					root.get(AbstractQueryableFacilityDataType_.lastUpdated), getData());
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's site id.
	 *
	 */
	static class FacilitySiteIdentifierCriteriaFactory extends
			AbstractCriteriaFactory<String, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			return cb.equal(cb.upper(root.get(AbstractQueryableFacilityDataType_.siteIdentifier)),
					getData().toUpperCase());
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the
	 * facility's originating partner name.
	 *
	 */
	static class OriginatingPartnerNameCriteriaFactory extends
			AbstractCriteriaFactory<String, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			return cb.equal(
					cb.upper(root.get(AbstractQueryableFacilityDataType_.originatingPartnerName)),
					getData().toUpperCase());
		}
	}

	/**
	 * Factory for creating a Facility-related where-clause based on the name of
	 * the system the Facility data is coming from.
	 *
	 */
	static class InformationSystemAcronymNameCriteriaFactory extends
			AbstractCriteriaFactory<String, AbstractQueryableFacilityDataType> {

		@Override
		public Predicate create(final Root<? extends AbstractQueryableFacilityDataType> root,
				final CriteriaQuery<?> query, final CriteriaBuilder cb) {
			return cb.equal(cb.upper(root
					.get(AbstractQueryableFacilityDataType_.informationSystemAcronymName)),
					getData().toUpperCase());
		}
	}
}