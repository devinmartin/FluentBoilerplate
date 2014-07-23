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
    internal sealed class Response:IResponse
    {
        public IResultCode Result { get; private set; }
        public bool IsSuccess { get; private set; }
        public Response(IResultCode result)
        {
            this.Result = result;
        }
    }
    internal sealed class Response<T>:IResponse<T>
    {
        public T Content { get; private set; }
        public IResultCode Result { get; private set; }
        public bool IsSuccess { get; private set; }

        public Response(IResultCode result, T content)
        {
            this.Result = result;
            this.Content = content;
        }
    }
}
