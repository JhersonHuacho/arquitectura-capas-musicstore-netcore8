﻿namespace Huachin.MusicStore.Dto.Response
{
    public class BaseResponseGeneric<T> : BaseResponse
    {
		public T? Data { get; set; }
	}
}
