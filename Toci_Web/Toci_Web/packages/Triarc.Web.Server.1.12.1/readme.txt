Install-Package Microsoft.AspNet.WebApi.MessageHandlers.Compression

config.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));

To generate etags based on its content, use ETagFilterAttribute