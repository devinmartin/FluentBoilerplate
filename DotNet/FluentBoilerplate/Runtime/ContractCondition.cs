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

using FluentBoilerplate.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBoilerplate.Runtime
{
    internal abstract class ContractCondition:IContractCondition
    {
        private readonly Func<bool> condition;

        public ContractCondition(Func<bool> condition)
        {
            this.condition = condition;
        }
        public bool IsConditionMet()
        {
            return this.condition();
        }

        public abstract void Fail(Exception thrownException = null);
    }
}
