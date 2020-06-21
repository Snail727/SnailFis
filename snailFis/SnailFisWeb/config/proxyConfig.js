module.exports =  {
    proxy: {
     '/api': {
      target:'http://localhost:63834',  // 接口域名
         changeOrigin:true,  //是否跨域
         pathRewrite: {
             '^/api':'snailFis_api'  //需要rewrite的,
         }

     }
    }
}