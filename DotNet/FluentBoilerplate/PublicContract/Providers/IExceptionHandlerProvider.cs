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
using System.Collections.Immutable;

namespace FluentBoilerplate.Providers
{
    /// <summary>
    /// Represents a provider of exception handlers
    /// </summary>
    public interface IExceptionHandlerProvider 
    {
        /// <summary>
        /// Gets the handled exception types
        /// </summary>
        /// <value>
        /// The handled exception types
        /// </value>
        IImmutableSet<Type> HandledExceptionTypes { get; }

        /// <summary>
        /// Gets the handled types in catch order
        /// </summary>
        /// <value>
        /// The handled types in catch order
        /// </value>
        IImmutableQueue<Type> HandledTypesInCatchOrder { get; }

        /// <summary>
        /// Tries to get an exception handler for the exception type
        /// </summary>
        /// <typeparam name="TException">The exception type</typeparam>
        /// <returns>An instance of the exception handler, or null if not found</returns>
        IExceptionHandler<TException> TryGetHandler<TException>() where TException : Exception;

        /// <summary>
        /// Tries to get an exception handler for the exception type
        /// </summary>
        /// <typeparam name="TException">The exception type</typeparam>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <returns>An instance of the exception handler, or null if not found</returns>
        IExceptionHandler<TException, TResult> TryGetHandler<TException, TResult>() where TException : Exception;
        
        /// <summary>
        /// Adds the specified action as an exception handler
        /// </summary>
        /// <typeparam name="TException">The exception type</typeparam>
        /// <param name="action">The action</param>
        /// <returns>An instance of <see cref="IExceptionHandlerProvider"/> that contains the given exception handler</returns>
        IExceptionHandlerProvider Add<TException>(Action<TException> action) where TException : Exception;

        /// <summary>
        /// Adds the specified function as an exception handler
        /// </summary>
        /// <typeparam name="TException">The exception type</typeparam>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="action">The action</param>
        /// <returns>An instance of <see cref="IExceptionHandlerProvider"/> that contains the given exception handler</returns>
        IExceptionHandlerProvider Add<TException, TResult>(Func<TException, TResult> action) where TException : Exception;
    }
}
