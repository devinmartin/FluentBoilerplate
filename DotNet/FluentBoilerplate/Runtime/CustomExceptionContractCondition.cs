﻿/*
   Copyright 2014 Chris Hannon

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBoilerplate.Runtime
{
    internal sealed class CustomExceptionContractCondition<TException> : ContractCondition where TException : Exception
    {
        private readonly Func<Exception, TException> createExceptionWithException;
        private readonly Func<TException> createException;

        public CustomExceptionContractCondition(Func<bool> condition, Func<TException> createException)
            : base(condition)
        {
            this.createException = createException;
        }

        public CustomExceptionContractCondition(Func<bool> condition, Func<Exception, TException> createException)
            : base(condition)
        {
            this.createExceptionWithException = createException;
        }

        public override void Fail(Exception thrownException = null)
        {
            if (this.createExceptionWithException != null)
                throw this.createExceptionWithException(thrownException);
            else
                throw this.createException();
        }
    }
}
