﻿// -----------------------------------------------------------------------
//  <copyright file="LoggerBase.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-08-10 22:10</last-date>
// -----------------------------------------------------------------------

using System;

namespace BeiDream.Utils.Logging
{
    /// <summary>
    /// 日志输出者适配基类，用于定义日志输出的处理业务
    /// </summary>
    public abstract class LogBase : ILog
    {
        /// <summary>
        /// 获取日志输出处理委托实例
        /// </summary>
        /// <param name="level">日志输出级别</param>
        /// <param name="message">日志消息</param>
        /// <param name="exception">日志异常</param>
        /// <param name="isData">是否数据日志</param>
        protected abstract void Write(LogLevel level, object message, Exception exception, bool isData = false);

        #region Implementation of ILog

        /// <summary>
        /// 获取 是否数据日志对象
        /// </summary>
        public abstract bool IsDataLogging { get; }

        /// <summary>
        /// 获取 是否允许输出<see cref="LogLevel.Trace"/>级别的日志
        /// </summary>
        public abstract bool IsTraceEnabled { get; }

        /// <summary>
        /// 获取 是否允许输出<see cref="LogLevel.Debug"/>级别的日志
        /// </summary>
        public abstract bool IsDebugEnabled { get; }

        /// <summary>
        /// 获取 是否允许输出<see cref="LogLevel.Info"/>级别的日志
        /// </summary>
        public abstract bool IsInfoEnabled { get; }

        /// <summary>
        /// 获取 是否允许输出<see cref="LogLevel.Warn"/>级别的日志
        /// </summary>
        public abstract bool IsWarnEnabled { get; }

        /// <summary>
        /// 获取 是否允许输出<see cref="LogLevel.Error"/>级别的日志
        /// </summary>
        public abstract bool IsErrorEnabled { get; }

        /// <summary>
        /// 获取 是否允许输出<see cref="LogLevel.Fatal"/>级别的日志
        /// </summary>
        public abstract bool IsFatalEnabled { get; }

        /// <summary>
        /// 写入<see cref="LogLevel.Trace"/>日志消息
        /// </summary>
        /// <param name="message">日志消息</param>
        public virtual void Trace<T>(T message)
        {
            if (IsTraceEnabled)
            {
                Write(LogLevel.Trace, message, null);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Trace"/>格式化日志消息
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="args">格式化参数</param>
        public virtual void Trace(string format, params object[] args)
        {
            if (IsTraceEnabled)
            {
                Write(LogLevel.Trace, string.Format(format, args), null);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Debug"/>日志消息
        /// </summary>
        /// <param name="message">日志消息</param>
        public virtual void Debug<T>(T message)
        {
            if (IsDebugEnabled)
            {
                Write(LogLevel.Debug, message, null);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Debug"/>格式化日志消息
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="args">格式化参数</param>
        public virtual void Debug(string format, params object[] args)
        {
            if (IsDebugEnabled)
            {
                Write(LogLevel.Debug, string.Format(format, args), null);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Info"/>日志消息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="isData">是否数据日志</param>
        public virtual void Info<T>(T message, bool isData)
        {
            if (IsInfoEnabled)
            {
                Write(LogLevel.Info, message, null, isData);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Info"/>格式化日志消息
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="args">格式化参数</param>
        public virtual void Info(string format, params object[] args)
        {
            if (IsInfoEnabled)
            {
                Write(LogLevel.Info, string.Format(format, args), null);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Warn"/>日志消息
        /// </summary>
        /// <param name="message">日志消息</param>
        public virtual void Warn<T>(T message)
        {
            if (IsWarnEnabled)
            {
                Write(LogLevel.Warn, message, null);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Warn"/>格式化日志消息
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="args">格式化参数</param>
        public virtual void Warn(string format, params object[] args)
        {
            if (IsWarnEnabled)
            {
                Write(LogLevel.Warn, string.Format(format, args), null);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Error"/>日志消息
        /// </summary>
        /// <param name="message">日志消息</param>
        public virtual void Error<T>(T message)
        {
            if (IsErrorEnabled)
            {
                Write(LogLevel.Error, message, null);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Error"/>格式化日志消息
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="args">格式化参数</param>
        public void Error(string format, params object[] args)
        {
            if (IsErrorEnabled)
            {
                Write(LogLevel.Error, string.Format(format, args), null);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Error"/>日志消息，并记录异常
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="exception">异常</param>
        public virtual void Error<T>(T message, Exception exception)
        {
            if (IsErrorEnabled)
            {
                Write(LogLevel.Error, message, exception);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Error"/>格式化日志消息，并记录异常
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="exception">异常</param>
        /// <param name="args">格式化参数</param>
        public virtual void Error(string format, Exception exception, params object[] args)
        {
            if (IsErrorEnabled)
            {
                Write(LogLevel.Error, string.Format(format, args), exception);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Fatal"/>日志消息
        /// </summary>
        /// <param name="message">日志消息</param>
        public virtual void Fatal<T>(T message)
        {
            if (IsFatalEnabled)
            {
                Write(LogLevel.Fatal, message, null);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Fatal"/>格式化日志消息
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="args">格式化参数</param>
        public void Fatal(string format, params object[] args)
        {
            if (IsFatalEnabled)
            {
                Write(LogLevel.Fatal, string.Format(format, args), null);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Fatal"/>日志消息，并记录异常
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="exception">异常</param>
        public virtual void Fatal<T>(T message, Exception exception)
        {
            if (IsFatalEnabled)
            {
                Write(LogLevel.Fatal, message, exception);
            }
        }

        /// <summary>
        /// 写入<see cref="LogLevel.Fatal"/>格式化日志消息，并记录异常
        /// </summary>
        /// <param name="format">日志消息格式</param>
        /// <param name="exception">异常</param>
        /// <param name="args">格式化参数</param>
        public virtual void Fatal(string format, Exception exception, params object[] args)
        {
            if (IsFatalEnabled)
            {
                Write(LogLevel.Fatal, string.Format(format, args), exception);
            }
        }

        #endregion Implementation of ILog
    }
}