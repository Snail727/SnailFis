<template>
    <div>
        <input v-focus>
        <button @click="Search">获取列表</button>
    </div>
</template>

<script>
export default {
    data(){  
        return{
            num1:1,
        }
    },
    methods:{
        Search(){
            var self =this;
            console.log(self.$allAxios);
            self.$allAxios.Dictionarys.GetDicList().then((res)=>{console.log(res)});
        },
    },
    filters:{
        numChange(value1,value2){
            return value1+1;
        }
    }
}
</script>