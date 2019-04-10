﻿using System;
using System.Collections.Generic;
using System.Reactive;
using Toggl.Foundation.Models.Interfaces;
using Toggl.PrimeRadiant;
using Toggl.PrimeRadiant.Models;

namespace Toggl.Foundation.DataSources.Interfaces
{
    public interface IDataSource<TThreadsafe, out TDatabase> : IBaseDataSource<TThreadsafe>
        where TDatabase : IDatabaseModel
        where TThreadsafe : TDatabase, IThreadSafeModel
    {
        IObservable<TThreadsafe> GetById(long id);

        IObservable<IEnumerable<TThreadsafe>> GetByIds(long[] ids);

        IObservable<TThreadsafe> ChangeId(long currentId, long newId);

        IObservable<IEnumerable<TThreadsafe>> GetAll(bool includeInaccessibleEntities = false);

        IObservable<IEnumerable<TThreadsafe>> GetAll(Func<TDatabase, bool> predicate, bool includeInaccessibleEntities = false);

        IObservable<IEnumerable<IConflictResolutionResult<TThreadsafe>>> DeleteAll(IEnumerable<TThreadsafe> entities);

        IObservable<Unit> Delete(long id);

        IObservable<IEnumerable<IConflictResolutionResult<TThreadsafe>>> BatchUpdate(IEnumerable<TThreadsafe> entities);
    }
}
