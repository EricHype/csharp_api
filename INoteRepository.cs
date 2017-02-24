using System.Collections.Generic;

namespace WebCore.API.Models
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAll();
        Note Find(string id);
        void Add(Note item);
        void Remove(string id);
    }
}