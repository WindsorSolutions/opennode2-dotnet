/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
 */

package com.windsor.node.common.util;

import java.io.Serializable;
import java.util.Collection;
import java.util.Iterator;
import java.util.Map;
import java.util.Random;
import java.util.Set;
import java.util.TreeMap;

import org.apache.commons.collections.MapUtils;
import org.apache.commons.lang3.builder.EqualsBuilder;
import org.apache.commons.lang3.builder.HashCodeBuilder;

/**
 * Simplification of the ByIndexOrNameMap from .NET Uses a simple internal Map
 * member.
 * 
 * <p>
 * Builds an internal key from index or uses one provided by the caller.
 * </p>
 * 
 * @author mchmarny
 */
public class ByIndexOrNameMap implements Serializable {

    private static final long serialVersionUID = 1;
    private static final int TEN = 10;
    private static final int HUNDRED = 100;
    private static final int THOUSAND = 1000;

    private Map map = null;

    public ByIndexOrNameMap() {
        map = MapUtils.typedMap(new TreeMap(), String.class, Object.class);
    }

    public ByIndexOrNameMap(String[] args) {
        this();

        if (args != null) {
            for (int i = 0; i < args.length; i++) {
                put(i, args[i]);
            }
        }
    }

    public ByIndexOrNameMap(Map keyValueMap) {
        this.setMap(keyValueMap);
    }

    public String[] toValueStringArray() {

        if (map == null) {
            return null;
        }

        int mapsize = map.size();

        String[] arrayOfStrings = new String[mapsize];
        Iterator keyValuePairs1 = map.entrySet().iterator();
        for (int i = 0; i < mapsize; i++) {
            Map.Entry entry = (Map.Entry) keyValuePairs1.next();
            arrayOfStrings[i] = (String) entry.getValue();
        }

        return arrayOfStrings;

    }

    public int size() {
        return map.size();
    }

    public Object put(String name, Object value) {
        return map.put(name, value);
    }

    public Object put(int index, Object value) {
        return map.put(getKeyFromInt(index), value);
    }

    public void clear() {
        map.clear();
    }

    public boolean containsKey(String key) {
        return map.containsKey(key);
    }

    public boolean containsValue(Object value) {
        return map.containsValue(value);
    }

    public Object get(String key) {
        return map.get(key);
    }

    public Object get(int index) {
        return get(getKeyFromInt(index));
    }

    public boolean isEmpty() {
        return map.isEmpty();
    }

    public Set keySet() {
        return map.keySet();
    }

    public Object remove(String key) {
        return map.remove(key);
    }

    public Collection values() {
        return map.values();
    }

    /**
     * getKeyFromInt
     * 
     * @param index
     * @return
     */
    private String getKeyFromInt(int index) {
        if (index < 0) {
            throw new UnsupportedOperationException(
                    "index must be greater than -1");
        }
        String result = "";

        if (index < TEN) {
            result = "00" + index;
        } else if (index < HUNDRED) {
            result = "0" + index;
        } else if (index < THOUSAND) {
            result = "" + index;
        } else {
            throw new UnsupportedOperationException(
                    "index must be greater than -1 and less than 1000");
        }

        return result;
    }

    private void setMap(Map map) {
        this.map = MapUtils.typedMap(map, String.class, Object.class);
    }

    public int hashCode() {
        Random r = new Random();
        int n = r.nextInt();
        if (n % 2 == 0) {
            n++;
        }
        return new HashCodeBuilder(n, n + 2).append(map).toHashCode();
    }

    public boolean equals(Object obj) {
        return EqualsBuilder.reflectionEquals(this, obj);
    }

    public String toString() {

        StringBuffer sb = new StringBuffer();

        for (Iterator it = map.entrySet().iterator(); it.hasNext();) {

            Map.Entry entry = (Map.Entry) it.next();
            sb.append("[key=" + entry.getKey() + ", value=" + entry.getValue()
                    + "] ");

        }

        return sb.toString();
    }
}