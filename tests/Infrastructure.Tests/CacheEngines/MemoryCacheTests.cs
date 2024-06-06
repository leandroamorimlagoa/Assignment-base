using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Infrastructure.CacheEngines;

namespace Infrastructure.Tests.CacheEngines;
[TestFixture]
public class MemoryCacheTests
{
    private MemoryCache<string> _cache;

    [SetUp]
    public void SetUp()
    {
        _cache = new MemoryCache<string>();
    }

    [Test]
    public void Set_ShouldAddItemToCache()
    {
        // Arrange
        var key = "testKey";
        string expectedValue = "testValue";
        var expiration = TimeSpan.FromMinutes(5);

        // Act
        _cache.Set(key, expectedValue, expiration);

        // Assert
        Assert.IsTrue(_cache.TryGetValue(key, out var cachedValue));

        Assert.NotNull(cachedValue);
        Assert.That(cachedValue, Is.EqualTo(expectedValue));
    }

    [Test]
    public void TryGetValue_ShouldReturnFalse_WhenItemIsNotInCache()
    {
        // Arrange
        var key = "nonExistentKey";

        // Act
        var result = _cache.TryGetValue(key, out var value);

        // Assert
        Assert.IsFalse(result);
        Assert.IsNull(value);
    }

    [Test]
    public void TryGetValue_ShouldReturnFalse_WhenItemIsExpired()
    {
        // Arrange
        var key = "testKey";
        var value = "testValue";
        var expiration = TimeSpan.FromMilliseconds(100);

        _cache.Set(key, value, expiration);

        // Wait for the item to expire
        Thread.Sleep(200);

        // Act
        var result = _cache.TryGetValue(key, out var cachedValue);

        // Assert
        Assert.IsFalse(result);
        Assert.IsNull(cachedValue);
    }

    [Test]
    public void TryGetValue_ShouldReturnTrue_WhenItemIsNotExpired()
    {
        // Arrange
        var key = "testKey";
        var expectedValue = "testValue";
        var expiration = TimeSpan.FromMinutes(5);

        _cache.Set(key, expectedValue, expiration);

        // Act
        var result = _cache.TryGetValue(key, out var cachedValue);

        // Assert
        Assert.IsTrue(result);
        Assert.IsNotNull(cachedValue);
        Assert.That(cachedValue, Is.EqualTo(expectedValue));
    }

    [Test]
    public void Remove_ShouldRemoveItemFromCache()
    {
        // Arrange
        var key = "testKey";
        var value = "testValue";
        var expiration = TimeSpan.FromMinutes(5);

        _cache.Set(key, value, expiration);

        // Act
        _cache.Remove(key);

        // Assert
        Assert.IsFalse(_cache.TryGetValue(key, out var cachedValue));
    }

    [Test]
    public void Clear_ShouldRemoveAllItemsFromCache()
    {
        // Arrange
        var key1 = "testKey1";
        var value1 = "testValue1";
        var expiration1 = TimeSpan.FromMinutes(5);

        var key2 = "testKey2";
        var value2 = "testValue2";
        var expiration2 = TimeSpan.FromMinutes(5);

        _cache.Set(key1, value1, expiration1);
        _cache.Set(key2, value2, expiration2);

        // Act
        _cache.Clear();

        // Assert
        Assert.IsFalse(_cache.TryGetValue(key1, out var cachedValue1));
        Assert.IsFalse(_cache.TryGetValue(key2, out var cachedValue2));
    }
}
