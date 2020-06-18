<template>
  <div>
    首页
    {{isSuccess?"请求成功":"请求失败"}}
  </div>
</template>

<script>
export default {
    created(){
        var self =this;
        self.Init();
    },
    components:{},
    data(){
        return{
            isSuccess:false
        }
    },
    methods:{
        Init(){
            var self =this;
            self.$allAxios.Dictionarys.GetDicList().then((res)=>{
                self.isSuccess=res.Success;
                });
        },
    }
}
</script>