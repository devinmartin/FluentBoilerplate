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

using FluentBoilerplate.Messages;
using FluentBoilerplate.Messages.Developer;
using FluentBoilerplate.Runtime.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using FluentBoilerplate.Providers;

namespace FluentBoilerplate.Runtime.Providers.ErrorHandling
{    
    internal sealed class TryCatchBlock : ITryCatchBlock
    {       
        private class ExceptionAwareAction<TResult>:IExceptionAwareAction
        {
            private readonly Func<TResult> action;
            private readonly IExceptionHandlerProvider provider;
            
            public TResult Result { get; private set; }

            public ExceptionAwareAction(Func<TResult> action, IExceptionHandlerProvider provider)
            {
                this.action = action;
                this.provider = provider;
            }

            public void Do()
            {
                this.Result = this.action();
            }

            public void HandleException<TException>(TException exception) where TException : Exception
            {
                var handler = this.provider.TryGetHandler<TException, TResult>();
                this.Result = handler.HandleWithResult(exception);
            }
        }

        private class ExceptionAwareAction:IExceptionAwareAction
        {
            private readonly IExceptionHandlerProvider provider;
            private readonly Action action;

            public ExceptionAwareAction(Action action, IExceptionHandlerProvider provider)
            {
                this.action = action;
                this.provider = provider;
            }
            public void Do()
            {
                this.action();
            }
            public void HandleException<TException>(TException exception) where TException : Exception
            {
                var handler = this.provider.TryGetHandler<TException>();
                handler.Handle(exception);
            }
        }

        private readonly IImmutableSet<Type> handledTypes;
        private readonly Action<IExceptionAwareAction> tryCatch;
        private readonly IExceptionHandlerProvider provider;

        public IImmutableSet<Type> HandledExceptionTypes { get { return this.handledTypes; } }

        public TryCatchBlock(IImmutableSet<Type> handledTypes, 
                             Action<IExceptionAwareAction> tryCatch, 
                             IExceptionHandlerProvider provider)
        {
            this.handledTypes = handledTypes;
            this.tryCatch = tryCatch;
            this.provider = provider;
        }

        public void Try(Action action)
        {
            var awareAction = new ExceptionAwareAction(action, this.provider);
            this.tryCatch(awareAction);
        }

        public TResult Try<TResult>(Func<TResult> action) 
        {
            var awareAction = new ExceptionAwareAction<TResult>(action, this.provider);
            this.tryCatch(awareAction);
            return awareAction.Result;
        }        
    }
}
