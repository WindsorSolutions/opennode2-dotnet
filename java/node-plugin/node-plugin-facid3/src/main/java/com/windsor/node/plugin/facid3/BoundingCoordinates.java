package com.windsor.node.plugin.facid3;

/**
 * Groups the bounding latitude and longitude coordinates together.
 *
 */
public class BoundingCoordinates {

	private final double northLatitude;
	private final double southLatitude;
	private final double eastLongitude;
	private final double westLongitude;

	public BoundingCoordinates(final double northLatitude, final double southLatitude, final double eastLongitude,
			final double westLongitude) {
		this.northLatitude = northLatitude;
		this.southLatitude = southLatitude;
		this.eastLongitude = eastLongitude;
		this.westLongitude = westLongitude;
	}

	public double getNorthLatitude() {
		return northLatitude;
	}

	public double getSouthLatitude() {
		return southLatitude;
	}

	public double getEastLongitude() {
		return eastLongitude;
	}

	public double getWestLongitude() {
		return westLongitude;
	}

}