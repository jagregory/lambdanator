/*
 * Copyright (c) 2011, James Gregory
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are permitted
 * provided that the following conditions are met:
 *
 *  * Redistributions of source code must retain the above copyright notice, this list of conditions
 *    and the following disclaimer.
 *  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions
 *    and the following disclaimer in the documentation and/or other materials provided with the distribution.
 *  * Neither the name of Lambdanator, James Gregory nor the names of its contributors may be used
 *    to endorse or promote products derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 * PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
 * PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
 * OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
 * SUCH DAMAGE.
 */

using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Lambdanator
{
    public class λ
    {
        public static MemberInfo Reflect(Expression<Func<object>> expression)
        {
            return Reflect(expression.Body);
        }
        
        public static MemberInfo Reflect<T>(Expression<Func<T, object>> expression)
        {
            return Reflect(expression.Body);
        }

        public static MemberInfo Reflect(Expression<Action> expression)
        {
            return Reflect(expression.Body);
        }

        public static MemberInfo Reflect<T>(Expression<Action<T>> expression)
        {
            return Reflect(expression.Body);
        }

        public static MemberInfo Reflect(Expression expression)
        {
            var memberAccess = expression as MemberExpression;

            if (memberAccess != null)
                return memberAccess.Member;

            var unary = expression as UnaryExpression;

            if (unary != null)
                return Reflect(unary.Operand);

            var call = expression as MethodCallExpression;

            if (call != null)
                return call.Method;

            throw new ArgumentException("Not a member access", "expression");
        }
    }

    public class Lambda : λ
    {}
}