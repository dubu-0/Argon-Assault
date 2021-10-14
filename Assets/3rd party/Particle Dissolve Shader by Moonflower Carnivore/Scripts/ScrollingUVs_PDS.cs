using UnityEngine;

namespace _3rd_party.Particle_Dissolve_Shader_by_Moonflower_Carnivore.Scripts
{
	public class ScrollingUVs_PDS : MonoBehaviour 
	{
		public int materialIndex = 0;
		public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );
		public string textureName = "_MainTex";
	
		Vector2 uvOffset = Vector2.zero;
	
		void LateUpdate() 
		{
			uvOffset += ( uvAnimationRate * Time.deltaTime );
			if( GetComponent<Renderer>().enabled )
			{
				GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( textureName, uvOffset );
			}
		}
	}
}