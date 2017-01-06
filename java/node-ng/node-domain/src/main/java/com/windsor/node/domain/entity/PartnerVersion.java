package com.windsor.node.domain.entity;

import java.util.Map;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import com.windsor.stack.domain.IIdentifiable;

/**
 * Provides an enumeration of valid Partner protocol versions.
 */
public enum PartnerVersion implements IIdentifiable<String> {

    ONE_DOT_ONE("EN11", "1.1"),
    TWO_DOT_ONE("EN2.1", "2.1"),
    REST("ENREST", "REST");

    private static final Map<String, PartnerVersion> ID_MAP = Stream.of(PartnerVersion.values())
            .collect(Collectors.toMap(PartnerVersion::getId, e -> e));

    private String id;
    private String description;

    PartnerVersion(String id, String description) {
        this.id = id;
        this.description = description;
    }

    @Override
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public static Stream<PartnerVersion> getMatches(String term) {
        return Stream.of(values())
                .filter(dsp -> dsp.getDescription().toLowerCase().contains(term.toLowerCase()));
    }

    public static Optional<PartnerVersion> findById(long id) {
        return Optional.ofNullable(ID_MAP.get(id));
    }

    public static PartnerVersion fromString(String id) {

        PartnerVersion partnerVersion = null;

        for(PartnerVersion versionThis : PartnerVersion.values()){
            if(versionThis.getId().equals(id)) {
                partnerVersion = versionThis;
                break;
            }
        }

        return partnerVersion;
    }

    @Override
    public String toString() {
        return description;
    }
}
