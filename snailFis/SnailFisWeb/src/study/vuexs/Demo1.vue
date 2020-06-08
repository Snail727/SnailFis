<template>
    <div>
        <span v-for="todo in $store.getters.nameTodos" :key="todo.id">{{todo}}</span><br>
        <span v-for="todo in $store.getters.getTodoById(2)" :key="todo.id">{{todo}}</span><br>
        <span v-for="todo in nameTodos" :key="todo.id">{{todo}}</span><br>
        <span>{{$store.state.count}}</span>
        <button @click="Add1">+1</button>
        <button @click="Add2">+10</button>
        <button @click="Add3">+2</button>
        <button @click="Add4">+1</button>
        <button @click="Add5">+10</button>
        <button @click="Add6">+11</button>
    </div>
</template>

<script>

import { mapGetters } from 'vuex'
import { mapMutations } from 'vuex'
import * as Mutations from '@/store/mutation-types.js'
export default {
    data(){
        return{

        }
    },
    methods:mapMutations({
        Add1(){
            this.$store.commit('increment');
        },
        Add2(){
            this.$store.commit('incrementObj',{count:10});
        },
        Add3(){
            this.$store.commit(Mutations.SOME_MUTATION);
        },
        Add4:'increment',
        Add5(){
            this.$store.dispatch('incrementObj',{count:10}).then(()=>{
                alert('success');
            });
        },
        Add6(){
            //this.$store.dispatch('increment12',{count:10});
        }
    }),
    computed:mapGetters({
        nameTodos:'nameTodos'
    }),
}
</script>
