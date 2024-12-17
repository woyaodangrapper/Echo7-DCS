# src

框架开发目录:

| Sample                           | Description                                                                                                                                                                                    |
|----------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [1. Application Core](./Application%20Core) | 应用核心及领域模型.
| [3. Application Services](./Application%20Services)  | 应用服务.
| [4. Infrastructure](./Infrastructure) | 适配器/外部引用/图形显示等.


**核心**
- Application Core - 应用核心及领域模型
  - Domain - 服务领域
    - Core - 核心
      - Wechat - 微信模块
    - Support - 支撑
      - Maint - 运维模块
      - User - 用户模块
  
  - SharedKernel - 公用工程/Consts存放常量定义文件、Events存放事件定义文件
    - ApiService - 该层实现了认证、鉴权、异常捕获、服务组件注册等公共类和中间件。所有Service层的共享层，并且都需要依赖该层。
    - Application - 定义DTO对象的基类、应用服务类基类、缓存相关服务基类以及操作日志拦截器、UnitOfWork拦截器。所有微服务Application层的共享层，并且都需要依赖该层。
    - Contracts - DDD依赖
    - Domain - DDD依赖
    - Repository - DDD依赖
    - Rpc - 该层负责proto文件的定义、refit接口定义以及DelegatingHandler实现。微服务同步通讯主要由该层处理，支持Grpc与RestAPI两种通讯方式混用。

- Application Services - 应用服务
  - Gateway.Ocelot - 网关包含路由、服务聚合、服务发现、认证、鉴权、限流、熔断、缓存、Header头传递等功能。市面上主流网关还有Kong，Traefik，Ambassador，Tyk等等。网关和实际业务有没有关联，可以自由选择。
  - Maint.ApiService - 运维服务 经典三层
  - User.ApiService - 用户服务 经典三层
  - Wechat.ApiService - 微信服务 经典三层

- Infrastructure - 基础架构/外部引用/图形显示等
  - Client - 客户端
  - Caching - Redis，提供缓存的管理、Redis常用类型操作、分布式锁、布隆过滤器功能。
  - Consul - 提供服务的自动注册、发现以及系统配置读写操作。
  - Core - 工程的最顶层，任何工程都会者直接或间接依赖该层。该工程提供了大量的C#基础类型的扩展方法以及Configuration、DependencyInjection、ContainerBuilder的扩展方法，还定义了一些异常类。
  - EventBus - 简单封装了CAP，同时集成了RabbitMq，封装了发布者与订阅者等公共类，能让开发人员更加便捷的调用。
  - Helper - 提供一些通用帮助类，如HashHelper,SecurityHelper等等。
  - IdGenerater - 负责Id的生成。
  - Mapper - 定义了IObjectMapper接口，并且提供了AutoMapper的实现。
  - Repository - 工程定义了Entity对象的基类、UnitOfWork接口、仓储接口。
  - Repository.Dapper - 负责Repository仓储接口以及IUintofWork接口的EfCore的实现，也集成了Dapper部分接口，用来处理复杂查询。
  - Repository.EfCore
  - Repository.EfCore.MySQL - 仓储接口IAdoExecuterWithQuerierRepository的实现，提供mysql数据库的CURD操作。
  - Repository.EfCore.SQLServer
  - Repository.Mongo - 仓储接口的Mongodb实现，提供mongodb数据库的CURD操作。

## 采用设计模式

**领域服务及模型**

  - 等待统一(文档尚未完成)

**应用服务及应用**

- 创建型

  - 抽象工厂模式（Abstract Factory）

- 结构型

  - 装饰者模式（Decorator Pattern）

- 行为型

  - 命令模式（Command Pattern）
