<template>
  <div class="container-fluid">
    <div class="row mt-3 mx-3">
      <div class="hoverable" v-for="d in destinations" :key="d.id">
        <DestinationButtons :destination="d" />
      </div>
    </div>
    <div class="row mx-3">
      <div class="col-12 bg-blue">fhdjkshfkdjsh</div>
    </div>
  </div>
</template>

<script>
import { computed, watchEffect } from "@vue/runtime-core"
import { logger } from "../utils/Logger"
import { destinationsService } from "../services/DestinationsService"
import { AppState } from "../AppState"
export default {
  name: 'Home',
  setup() {
    watchEffect(async () => {
      try {
        await destinationsService.getAllDestinations()
      } catch (error) {
        logger.error(error)
      }
    });
    return {
      destinations: computed(() => AppState.destinations)
    }
  }
}
</script>

<style scoped lang="scss">
.hoverable:hover {
  transform: scale(1.01);
  filter: drop-shadow(0px 15px 10px rgba(0, 0, 0, 0.3));
  transition: 50ms ease-in-out;
  cursor: pointer;
}
.hoverable:active {
  transform: scale(0.999);
  transition: 50ms ease-in-out;
}
</style>
