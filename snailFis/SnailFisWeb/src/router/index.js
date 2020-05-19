import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
import Demo from '@/baseData/Demo'
import Demo1 from '@/baseData/Demo1'
import Demo2 from '@/baseData/Demo2'
import Demo3 from '@/baseData/Demo3'
import Demo4 from '@/baseData/Demo4'
import Demo5 from '@/baseData/Demo5'
import Demo6 from '@/baseData/Demo6'
import Demo7 from '@/baseData/Demo7'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HelloWorld',
      component: HelloWorld
    },
    {
      path: '/Demo',
      name: 'Demo',
      component: Demo
    },
    {
      path: '/Demo1',
      name: 'Demo1',
      component: Demo1
    },
    {
      path: '/Demo2',
      name: 'Demo2',
      component: Demo2
    },
    {
      path: '/Demo3',
      name: 'Demo3',
      component: Demo3
    },
    {
      path: '/Demo4',
      name: 'Demo4',
      component: Demo4
    },
    {
      path: '/Demo5',
      name: 'Demo5',
      component: Demo5
    },
    {
      path: '/Demo6',
      name: 'Demo6',
      component: Demo6
    },
    {
      path: '/Demo7',
      name: 'Demo7',
      component: Demo7
    },
  ]
})
