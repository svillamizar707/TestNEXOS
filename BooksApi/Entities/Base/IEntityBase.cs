﻿namespace BooksApi.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
