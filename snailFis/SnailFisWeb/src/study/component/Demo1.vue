<template>
    <div>
        <button @click="bool1=!bool1">change</button>
        <demo-span v-if="bool1"></demo-span>
    </div>
</template>

<script>
export default {
    components:{
        "demo-span":()=>import("./DemoSpan")
    },
    data(){  
        return{
            bool1:false,
        }
    },
    methods:{
    }
}
</script>