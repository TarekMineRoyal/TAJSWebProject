using Domain.Entities;

namespace Application.IServices;

public interface ITagService
{
    public IEnumerable<Tag>? GetAllTags();

    public Tag? GetTagById(int id);

    public Tag AddTag(Tag tag);

    public Tag UpdateTag(Tag tag);

    public Tag? DeleteTag(int id);

    public Task<IEnumerable<Tag>?> GetAllTagsAsync();

    public Task<Tag?> GetTagByIdAsync(int id);

    public Task<Tag> AddTagAsync(Tag tag);

    public Task<Tag > UpdateTagAsync(Tag tag);

    public Task<Tag?> DeleteTagAsync(int id);
}
