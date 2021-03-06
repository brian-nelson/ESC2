using System;

// This file is generated from the database.  Do not manually edit.
// Generated by: https://github.com/brian-nelson/repo-generator

namespace ESC2.Library.Data.Interfaces
{
    public interface IDataRepo<T, U> where T:IDataObject<U>
    {
        U Save(T obj);
        T GetById(U id);
        void Delete(U id);
    }
}
