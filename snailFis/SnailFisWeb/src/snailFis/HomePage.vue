<template>
  <div>
    首页
    {{isSuccess?"请求成功":"请求失败"}}
    <button @click="init">查询</button>
    <button @click="exit">退出</button>
  </div>
</template>

<script>
export default {
    created(){
        var self =this;
        self.init();
    },
    components:{},
    data(){
        return{
            isSuccess:false
        }
    },
    methods:{
        init(){
            var self =this;
            self.$allAxios.Dictionarys.GetDicList().then((res)=>{
                self.isSuccess=res.Success;
            });
        },
        exit(){
            var self =this;
            localStorage.setItem('token', JSON.stringify({}));//清除token
            self.$router.push('/Login');//跳转登陆页
        }
    }
}
</script>