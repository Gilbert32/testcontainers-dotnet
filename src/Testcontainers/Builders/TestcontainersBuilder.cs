namespace DotNet.Testcontainers.Builders
{
  using DotNet.Testcontainers.Configurations;
  using DotNet.Testcontainers.Containers;
  using JetBrains.Annotations;

  /// <inheritdoc cref="TestcontainersBuilder{TBuilderEntity, TContainerEntity, TConfigurationEntity}" />
  [PublicAPI]
  public sealed class TestcontainersBuilder : TestcontainersBuilder<TestcontainersBuilder, ITestcontainersContainer, ITestcontainersConfiguration>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TestcontainersBuilder" /> class.
    /// </summary>
    public TestcontainersBuilder()
      : this(new TestcontainersConfiguration())
    {
    }

    private TestcontainersBuilder(ITestcontainersConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    /// <inheritdoc cref="IAbstractBuilder{TBuilderEntity,TContainerEntity}" />
    public override ITestcontainersContainer Build()
    {
      return new TestcontainersContainer(this.DockerResourceConfiguration, TestcontainersSettings.Logger);
    }

    /// <inheritdoc cref="ICloneable{TBuilderEntity, IDockerResourceConfiguration}" />
    public override TestcontainersBuilder Clone(IDockerResourceConfiguration dockerResourceConfiguration)
    {
      return this.Clone(new TestcontainersConfiguration(dockerResourceConfiguration));
    }

    /// <inheritdoc cref="ICloneable{TBuilderEntity, ITestcontainersConfiguration}" />
    public override TestcontainersBuilder Clone(ITestcontainersConfiguration dockerResourceConfiguration)
    {
      return new TestcontainersBuilder(new TestcontainersConfiguration(dockerResourceConfiguration, this.DockerResourceConfiguration));
    }
  }
}
