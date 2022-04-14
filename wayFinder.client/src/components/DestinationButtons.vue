<template>
  <div @click="setActive" class="bg-blue text-center p-1 rounded-top">
    {{ destination.name }}
  </div>
</template>

<script>
import { ref } from "@vue/reactivity"
import { destinationsService } from "../services/DestinationsService"
import { reservationsService } from "../services/ReservationsService"
import { logger } from "../utils/Logger"
export default {
  props: {
    destination: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      props,
      async setActive() {
        try {
          await destinationsService.getDestinationById(props.destination.id)
          await reservationsService.getReservationsByDestinationId(props.destination.id)
        } catch (error) {
          logger.error(error)
        }
      },
    }
  }
}
</script>

<style>
</style>