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

package com.windsor.node.util;

import java.util.Random;

import org.apache.commons.lang3.StringUtils;

import com.windsor.node.service.helper.id.UUIDGenerator;

public final class PasswordUtil {

    private static final int LENGTH_LIMIT = 9;
    private static final int DEFAULT_NAAS_PASS_LEN = 5;

    private PasswordUtil() {
    }

    /**
     * Generates random NAAS Password 8 chars long
     * 
     * @return
     */
    public static String getRandomNAASPassword() {
        return getRandomNAASPassword(DEFAULT_NAAS_PASS_LEN);
    }

    /**
     * Generates random NAAS Password
     * 
     * @return
     */
    public static String getRandomNAASPassword(int len) {

        StringBuffer buffer = new StringBuffer();
        Random random = new Random();

        char[] chars = StringUtils.remove(
                StringUtils.remove(UUIDGenerator.makeId(), '_'), '-')
                .toCharArray();
        for (int i = 0; i < len; i++) {
            buffer.append(chars[random.nextInt(chars.length)]);
        }

        // Prefex with Windsor Pass
        return "Wp" + buffer.toString() + rand(0, LENGTH_LIMIT);

    }

    private static int rand(int lo, int hi) {
        java.util.Random rn = new java.util.Random();
        int n = hi - lo + 1;
        int i = rn.nextInt() % n;
        if (i < 0) {
            i = -i;
        }
        return lo + i;
    }

}