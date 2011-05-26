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

/**
 * 
 */
package com.windsor.node.admin.ajax;

import java.util.ArrayList;
import java.util.List;
import java.util.TreeMap;

/**
 * A search service that returns a list of strings that searches upon an array
 * of strings. It will not return duplicate results.
 * 
 * @author Eric Chan
 * 
 */
public class StringArraySearchService implements SearchService {

    public List find(Object originalList, Object criteria, int maxResults) {

        List resultList;

        // some boundary checking
        if (criteria == null
                || !String.class.isAssignableFrom(criteria.getClass())) {
            resultList = null;
        }

        else if (originalList == null
                || !String[].class.isAssignableFrom(originalList.getClass())) {
            resultList = null;

        } else {

            String user = (String) criteria;
            String[] list = (String[]) originalList;

            // we put it into a Treemap to make sure it is sorted by index of
            // the
            // searched term.
            TreeMap map = new TreeMap();

            for (int i = 0; i < list.length; i++) {
                // make sure we have a match and there are no dups
                if (list[i] != null
                        && list[i].toUpperCase().indexOf(user.toUpperCase()) >= 0
                        && !map.containsValue(list[i])) {
                    map.put(list[i].toUpperCase().indexOf(user.toUpperCase())
                            + list[i], list[i]);
                }
            }
            resultList = new ArrayList(map.values());

            // we only want to return a part of the list.
            if (resultList.size() > maxResults) {
                return resultList.subList(0, maxResults);
            }
        }
        return resultList;
    }

}