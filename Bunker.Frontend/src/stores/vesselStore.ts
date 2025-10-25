import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import vesselService from '@/services/vesselService'
import type { 
  Vessel, 
  CreateVesselRequest, 
  UpdateVesselRequest, 
  VesselListQuery,
  PaginationInfo 
} from '@/types'

export const useVesselStore = defineStore('vessel', () => {
  // State
  const vessels = ref<Vessel[]>([])
  const currentVessel = ref<Vessel | null>(null)
  const loading = ref(false)
  const error = ref<string | null>(null)
  const pagination = ref<PaginationInfo>({
    pageNumber: 1,
    pageSize: 10,
    totalCount: 0,
    totalPages: 0
  })

  // Getters
  const vesselCount = computed(() => vessels.value.length)
  const hasVessels = computed(() => vessels.value.length > 0)
  const isLoading = computed(() => loading.value)
  const hasError = computed(() => error.value !== null)

  // Actions
  const setLoading = (value: boolean) => {
    loading.value = value
  }

  const setError = (message: string | null) => {
    error.value = message
  }

  const clearError = () => {
    error.value = null
  }

  const setVessels = (vesselList: Vessel[]) => {
    vessels.value = vesselList
  }

  const setCurrentVessel = (vessel: Vessel | null) => {
    currentVessel.value = vessel
  }

  const setPagination = (paginationInfo: PaginationInfo) => {
    pagination.value = paginationInfo
  }

  const addVessel = (vessel: Vessel) => {
    vessels.value.unshift(vessel)
  }

  const updateVesselInList = (updatedVessel: Vessel) => {
    const index = vessels.value.findIndex(v => v.id === updatedVessel.id)
    if (index !== -1) {
      vessels.value[index] = updatedVessel
    }
  }

  const removeVesselFromList = (vesselId: number) => {
    const index = vessels.value.findIndex(v => v.id === vesselId)
    if (index !== -1) {
      vessels.value.splice(index, 1)
    }
  }

  // API Actions
  const fetchVessels = async (query: VesselListQuery = {}) => {
    try {
      setLoading(true)
      clearError()
      
      const response = await vesselService.getAllVessels(query)
      setVessels(response.vessels)
      setPagination({
        pageNumber: response.pageNumber,
        pageSize: response.pageSize,
        totalCount: response.totalCount,
        totalPages: response.totalPages
      })
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Failed to fetch vessels'
      setError(errorMessage)
      console.error('Error fetching vessels:', err)
    } finally {
      setLoading(false)
    }
  }

  const fetchVesselById = async (id: number) => {
    try {
      setLoading(true)
      clearError()
      
      const vessel = await vesselService.getVesselById(id)
      setCurrentVessel(vessel)
      return vessel
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Failed to fetch vessel'
      setError(errorMessage)
      console.error('Error fetching vessel:', err)
      throw err
    } finally {
      setLoading(false)
    }
  }

  const createVessel = async (vesselData: CreateVesselRequest) => {
    try {
      setLoading(true)
      clearError()
      
      const response = await vesselService.createVessel(vesselData)
      if (response.success && response.data) {
        addVessel(response.data)
        return response.data
      } else {
        throw new Error(response.message || 'Failed to create vessel')
      }
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Failed to create vessel'
      setError(errorMessage)
      console.error('Error creating vessel:', err)
      throw err
    } finally {
      setLoading(false)
    }
  }

  const updateVessel = async (id: number, vesselData: UpdateVesselRequest) => {
    try {
      setLoading(true)
      clearError()
      
      const response = await vesselService.updateVessel(id, vesselData)
      if (response.success && response.data) {
        updateVesselInList(response.data)
        if (currentVessel.value?.id === id) {
          setCurrentVessel(response.data)
        }
        return response.data
      } else {
        throw new Error(response.message || 'Failed to update vessel')
      }
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Failed to update vessel'
      setError(errorMessage)
      console.error('Error updating vessel:', err)
      throw err
    } finally {
      setLoading(false)
    }
  }

  const deleteVessel = async (id: number) => {
    try {
      setLoading(true)
      clearError()
      
      const response = await vesselService.deleteVessel(id)
      if (response.success) {
        removeVesselFromList(id)
        if (currentVessel.value?.id === id) {
          setCurrentVessel(null)
        }
      } else {
        throw new Error(response.message || 'Failed to delete vessel')
      }
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Failed to delete vessel'
      setError(errorMessage)
      console.error('Error deleting vessel:', err)
      throw err
    } finally {
      setLoading(false)
    }
  }

  const resetStore = () => {
    vessels.value = []
    currentVessel.value = null
    loading.value = false
    error.value = null
    pagination.value = {
      pageNumber: 1,
      pageSize: 10,
      totalCount: 0,
      totalPages: 0
    }
  }

  return {
    // State
    vessels,
    currentVessel,
    loading,
    error,
    pagination,
    
    // Getters
    vesselCount,
    hasVessels,
    isLoading,
    hasError,
    
    // Actions
    setLoading,
    setError,
    clearError,
    setVessels,
    setCurrentVessel,
    setPagination,
    addVessel,
    updateVesselInList,
    removeVesselFromList,
    
    // API Actions
    fetchVessels,
    fetchVesselById,
    createVessel,
    updateVessel,
    deleteVessel,
    resetStore
  }
})
