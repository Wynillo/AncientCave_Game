using SpritesheetManagement;
using SpritesheetManagement.models;

namespace AncientCave.Test.SpritesheetManagement;

public class SpriteLoaderTests
{
    // Loading sprites from a valid JSON file returns a list of Sprite objects.
    [Test]
    public void test_loading_sprites_from_valid_json_file()
    {
        // Arrange
        var filePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\TestData\valid_sprites.json";

        // Act
        var sprites = SpriteLoader.LoadFromJsonFile(filePath);

        // Assert
        Assert.That(sprites, Is.Not.Null);
        Assert.That(sprites, Is.InstanceOf<List<Sprite>>());
        Assert.That(sprites, Is.Not.Empty);
    }
}

