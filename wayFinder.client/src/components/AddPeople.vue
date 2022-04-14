<template>
  <a @click="goTo('Dest')" class="text-light"
    >Add people to {{ destination.name }}</a
  >
</template>

<script>
import { useRouter } from "vue-router"
export default {
  props: {
    destination: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const router = useRouter();
    return {
      goTo(page) {
        router.push({
          name: page,
          params: { id: props.destination.id }
        });
      }
    }
  }
}
</script>

<style>
</style>