namespace DataAccessLayer.Tests
{
    using System;
    using DataAccessLayer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// ������� ��� ��� ���������� ��������� ������ ������������ (<see cref="IEntityTypeConfiguration{TEntity}"/>).
    /// </summary>
    internal abstract class BaseConfigurationTests
    {
        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="BaseConfigurationTests"/>.
        /// </summary>
        /// <param name="minimumLogLevel"> ����������� ������� ���������� ���������. </param>
        /// <exception cref="Exception">
        /// � ������ ������������� ����������/��������� ��������� ������� � ������.
        /// </exception>
        protected BaseConfigurationTests(LogLevel minimumLogLevel = LogLevel.Debug)
        {
            this.DataContext = new ServiceCollection()
                .AddDbContext<DataContext>(
                    options => options
                        .UseInMemoryDatabase($"InMemoryDB_{Guid.NewGuid()}")
                        .EnableDetailedErrors()
                        .EnableSensitiveDataLogging()
                        .LogTo(Console.WriteLine, minimumLogLevel))
                .BuildServiceProvider()
                .GetService<DataContext>()
                ?? throw new Exception($"Cannot get {typeof(DataContext).FullName} from DI");
        }

        /// <summary>
        /// �������� ������� � ������.
        /// </summary>
        protected DataContext DataContext { get; }
    }
}