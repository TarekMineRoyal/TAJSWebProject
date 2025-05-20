using Application.IRepositories;
using Application.IServices;
using Domain.Entities;

namespace Application.Services;

public class TagService : ITagService
{
    private readonly IGenericRepository<Tag> tagRepository;

    public TagService(IGenericRepository<Tag> tagRepository)
    {
        this.tagRepository = tagRepository;
    }

    public Tag AddTag(Tag tag)
    {
        tagRepository.Add(tag);
        tagRepository.SaveChanges();

        return tag;
    }

    public async Task<Tag> AddTagAsync(Tag tag)
    {
        await tagRepository.AddAsync(tag);
        await tagRepository.SaveChangesAsync();

        return tag;
    }

    public Tag? DeleteTag(int id)
    {
        var tag = tagRepository.Remove(id);
        tagRepository.SaveChanges();

        return tag;
    }

    public async Task<Tag?> DeleteTagAsync(int id)
    {
        var tag = tagRepository.Remove(id);
        await tagRepository.SaveChangesAsync();

        return tag;
    }

    public IEnumerable<Tag>? GetAllTags()
    {
        return tagRepository.GetAll();
    }

    public async Task<IEnumerable<Tag>?> GetAllTagsAsync()
    {
        return await tagRepository.GetAllAsync();
    }

    public Tag? GetTagById(int id)
    {
        return tagRepository.GetById(id);
    }

    public async Task<Tag?> GetTagByIdAsync(int id)
    {
        return await tagRepository.GetByIdAsync(id);
    }

    public Tag UpdateTag(int id, Tag tag)
    {
        tagRepository.UpdateAsync(id, tag);
        tagRepository.SaveChanges();

        return tag;
    }

    public async Task<Tag> UpdateTagAsync(int id, Tag tag)
    {
        await tagRepository.UpdateAsync(id, tag);
        await tagRepository.SaveChangesAsync();

        return tag;
    }
}
