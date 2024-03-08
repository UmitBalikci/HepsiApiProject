﻿using HepsiApiProject.Application.Interfaces.RedisCache;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Application.Behaviors
{
    public class RedisCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService _redisCacheService;
        public RedisCacheBehavior(IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is ICacheableQuery query)
            {
                var cacheKey = query.CacheKey;
                var cacheTime = query.CacheTime;

                var cacheData = await _redisCacheService.GetAsync<TResponse>(cacheKey);

                if (cacheData is not null)
                    return cacheData;

                var response = await next();

                if (response is not null)
                    await _redisCacheService.SetAsync(cacheKey, response, DateTime.Now.AddMinutes(cacheTime));
                
                return response;
            }

            return await next();
        }
    }
}
