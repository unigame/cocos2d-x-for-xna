/****************************************************************************
Copyright (c) 2010-2011 cocos2d-x.org
Copyright (C) 2008      Apple Inc. All Rights Reserved.

http://www.cocos2d-x.org

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//#include <string>
//#include "CCObject.h"
//#include "CCGeometry.h"
//#include "ccTypes.h"

namespace cocos2d
{
    public enum CCTexture2DPixelFormat
    {
	    kCCTexture2DPixelFormat_Automatic = 0,
	    //! 32-bit texture: RGBA8888
	    kCCTexture2DPixelFormat_RGBA8888,
	    //! 24-bit texture: RGBA888
	    kCCTexture2DPixelFormat_RGB888,
	    //! 16-bit texture without Alpha channel
	    kCCTexture2DPixelFormat_RGB565,
	    //! 8-bit textures used as masks
	    kCCTexture2DPixelFormat_A8,
	    //! 8-bit intensity texture
	    kCCTexture2DPixelFormat_I8,
	    //! 16-bit textures used as masks
	    kCCTexture2DPixelFormat_AI88,
	    //! 16-bit textures: RGBA4444
	    kCCTexture2DPixelFormat_RGBA4444,
	    //! 16-bit textures: RGB5A1
	    kCCTexture2DPixelFormat_RGB5A1,	
	    //! 4-bit PVRTC-compressed texture: PVRTC4
	    kCCTexture2DPixelFormat_PVRTC4,
	    //! 2-bit PVRTC-compressed texture: PVRTC2
	    kCCTexture2DPixelFormat_PVRTC2,

	    //! Default texture format: RGBA8888
	    kCCTexture2DPixelFormat_Default = kCCTexture2DPixelFormat_RGBA8888,

	    // backward compatibility stuff
	    kTexture2DPixelFormat_Automatic = kCCTexture2DPixelFormat_Automatic,
	    kTexture2DPixelFormat_RGBA8888 = kCCTexture2DPixelFormat_RGBA8888,
	    kTexture2DPixelFormat_RGB888 = kCCTexture2DPixelFormat_RGB888,
	    kTexture2DPixelFormat_RGB565 = kCCTexture2DPixelFormat_RGB565,
	    kTexture2DPixelFormat_A8 = kCCTexture2DPixelFormat_A8,
	    kTexture2DPixelFormat_RGBA4444 = kCCTexture2DPixelFormat_RGBA4444,
	    kTexture2DPixelFormat_RGB5A1 = kCCTexture2DPixelFormat_RGB5A1,
	    kTexture2DPixelFormat_Default = kCCTexture2DPixelFormat_Default
    } ;

    /**
    Extension to set the Min / Mag filter
    */
    public struct ccTexParams 
    {
	    uint minFilter;
        uint magFilter;
        uint wrapS;
        uint wrapT;
    };

    /** @brief CCTexture2D class.
    * This class allows to easily create OpenGL 2D textures from images, text or raw data.
    * The created CCTexture2D object will always have power-of-two dimensions. 
    * Depending on how you create the CCTexture2D object, the actual image area of the texture might be smaller than the texture dimensions i.e. "contentSize" != (pixelsWide, pixelsHigh) and (maxS, maxT) != (1.0, 1.0).
    * Be aware that the content of the generated textures will be upside-down!
    */
    public class CCTexture2D : CCObject
    {
        public CCTexture2D()
        {
            throw new NotImplementedException();
        }

	    ~CCTexture2D()
        {
            throw new NotImplementedException();
        }

	    public string description()
        {
            throw new NotImplementedException();
        }

	    /** These functions are needed to create mutable textures */
	    public void releaseData(object data)
        {
            throw new NotImplementedException();
        }
	    public object keepData(object data, uint length)
        {
            throw new NotImplementedException();
        }

	    /** Intializes with a texture2d with data */
	    public bool initWithData(object data, CCTexture2DPixelFormat pixelFormat, uint pixelsWide, uint pixelsHigh, CCSize contentSize)
        {
            throw new NotImplementedException();
        }

	    /**
	    Drawing extensions to make it easy to draw basic quads using a CCTexture2D object.
	    These functions require GL_TEXTURE_2D and both GL_VERTEX_ARRAY and GL_TEXTURE_COORD_ARRAY client states to be enabled.
	    */
	    /** draws a texture at a given point */
	    public void drawAtPoint(CCPoint point)
        {
            throw new NotImplementedException();
        }
	    /** draws a texture inside a rect */
	    public void drawInRect(CCRect rect)
        {
            throw new NotImplementedException();
        }

	    /**
	    Extensions to make it easy to create a CCTexture2D object from an image file.
	    Note that RGBA type textures will have their alpha premultiplied - use the blending mode (GL_ONE, GL_ONE_MINUS_SRC_ALPHA).
	    */
	    /** Initializes a texture from a UIImage object */
	    public bool initWithImage(CCImage uiImage)
        {
            throw new NotImplementedException();
        }

	    /**
	    Extensions to make it easy to create a CCTexture2D object from a string of text.
	    Note that the generated textures are of type A8 - use the blending mode (GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA).
	    */
	    /** Initializes a texture from a string with dimensions, alignment, font name and font size */
	    public bool initWithString(string text, CCSize dimensions, CCTextAlignment alignment, string fontName, float fontSize)
        {
            throw new NotImplementedException();
        }
	    /** Initializes a texture from a string with font name and font size */
	    public bool initWithString(string text, string fontName, float fontSize)
        {
            throw new NotImplementedException();
        }

	    /** returns the content size of the texture in points */
	    public CCSize getContentSize()
        {
            throw new NotImplementedException();
        }

#if CC_SUPPORT_PVRTC	
	    /**
	    Extensions to make it easy to create a CCTexture2D object from a PVRTC file
	    Note that the generated textures don't have their alpha premultiplied - use the blending mode (GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA).
	    */
	    /** Initializes a texture from a PVRTC buffer */
        public bool initWithPVRTCData(object data, int level, int bpp, bool hasAlpha, int length, CCTexture2DPixelFormat pixelFormat)
        {
            throw new NotImplementedException();
        }
#endif // CC_SUPPORT_PVRTC

        /** Initializes a texture from a PVR file */
	    public bool initWithPVRFile(string file)
        {
            throw new NotImplementedException();
        }

	    /** sets the min filter, mag filter, wrap s and wrap t texture parameters.
	    If the texture size is NPOT (non power of 2), then in can only use GL_CLAMP_TO_EDGE in GL_TEXTURE_WRAP_{S,T}.
	    @since v0.8
	    */
	    public void setTexParameters(ccTexParams texParams)
        {
            throw new NotImplementedException();
        }

	    /** sets antialias texture parameters:
	    - GL_TEXTURE_MIN_FILTER = GL_LINEAR
	    - GL_TEXTURE_MAG_FILTER = GL_LINEAR

	    @since v0.8
	    */
	    public void setAntiAliasTexParameters()
        {
            throw new NotImplementedException();
        }

	    /** sets alias texture parameters:
	    - GL_TEXTURE_MIN_FILTER = GL_NEAREST
	    - GL_TEXTURE_MAG_FILTER = GL_NEAREST

	    @since v0.8
	    */
	    public void setAliasTexParameters()
        {
            throw new NotImplementedException();
        }


	    /** Generates mipmap images for the texture.
	    It only works if the texture size is POT (power of 2).
	    @since v0.99.0
	    */
	    public void generateMipmap()
        {
            throw new NotImplementedException();
        }

	    /** returns the bits-per-pixel of the in-memory OpenGL texture
	    @since v1.0
	    */
        public uint bitsPerPixelForFormat()
        {
            throw new NotImplementedException();
        }

        public void setPVRImagesHavePremultipliedAlpha(bool haveAlphaPremultiplied)
        {
            throw new NotImplementedException();
        }
    
	    /** sets the default pixel format for UIImages that contains alpha channel.
	    If the UIImage contains alpha channel, then the options are:
	    - generate 32-bit textures: kCCTexture2DPixelFormat_RGBA8888 (default one)
	    - generate 24-bit textures: kCCTexture2DPixelFormat_RGB888
	    - generate 16-bit textures: kCCTexture2DPixelFormat_RGBA4444
	    - generate 16-bit textures: kCCTexture2DPixelFormat_RGB5A1
	    - generate 16-bit textures: kCCTexture2DPixelFormat_RGB565
	    - generate 8-bit textures: kCCTexture2DPixelFormat_A8 (only use it if you use just 1 color)

	    How does it work ?
	    - If the image is an RGBA (with Alpha) then the default pixel format will be used (it can be a 8-bit, 16-bit or 32-bit texture)
	    - If the image is an RGB (without Alpha) then an RGB565 or RGB888 texture will be used (16-bit texture)

	    @since v0.8
	    */
	    static public void setDefaultAlphaPixelFormat(CCTexture2DPixelFormat format)
        {
            throw new NotImplementedException();
        }

	    /** returns the alpha pixel format
	    @since v0.8
	    */
	    static public CCTexture2DPixelFormat defaultAlphaPixelFormat()
        {
            throw new NotImplementedException();
        }

        private bool initPremultipliedATextureWithImage(CCImage image, uint pixelsWide, uint pixelsHigh)
        {
            throw new NotImplementedException();
        }
    
        // By default PVR images are treated as if they don't have the alpha channel premultiplied
        private bool m_bPVRHaveAlphaPremultiplied;

        /** pixel format of the texture */
        private CCTexture2DPixelFormat pixelFormat { get; set; }
	    /** width in pixels */
        private uint pixelsWide { get; set; }
	    /** hight in pixels */
        private uint pixelsHigh { get; set; }

	    /** texture name */
        private uint name { get; set; }

	    /** content size */
        private CCSize contentSize { get; set; }
	    /** texture max S */
	    private float maxS { get; set;}
	    /** texture max T */
	    private float maxT { get; set;}
	    /** whether or not the texture has their Alpha premultiplied */
        private bool hasPremultipliedAlpha { get; set; }

    }
}